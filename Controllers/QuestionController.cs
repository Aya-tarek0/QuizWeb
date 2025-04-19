using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Quiz.DTO;
using Quiz.Interface;
using Quiz.Models;

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        IQuestionRepository questionRepo;
        IOptionRepository optionRepo;
        
        public QuestionController(IQuestionRepository questionRepository, IOptionRepository optionRepository)
        {
            questionRepo = questionRepository;
            optionRepo = optionRepository;
        }

        #region Get Question By BankID
        [HttpGet("{BankID:int}")]
        public IActionResult GetBankQuestions(int BankID)
        {
            List<GetBankQuestionDTO> Question = questionRepo.GetBankQuestion(BankID);

            if (Question != null && Question.Any())
            {
                NoContent();
            }
          
            return Ok(Question);
        }
        #endregion

        #region Filter Questions By type
        [HttpGet]
        [Route("{BankID:int}/{type:int}")]
        public IActionResult FilterByType(int BankID,int type)
        {
            List<GetBankQuestionDTO> Question = questionRepo.FilterQuestions(BankID, type);

            if (Question != null && Question.Any())
            {
                NoContent();
            }

            return Ok(Question);
        }
        #endregion

        #region Add Question
        [HttpPost]
        public IActionResult AddQuestion(AddOrEditQuestionDTO question)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newQuestion = new Question
                    {
                        Text = question.QstText,
                        CorrectAnswer = question.CorAnswer,
                        Type = (QuestionType)question.QuestionType,
                        BankID = question.BankID,
                    };

                    questionRepo.Add(newQuestion);
                    questionRepo.Save();

                    if(question.QuestionType == 0)
                    {
                        var newOption = new List<Option>
                    {
                        new Option { QuestionID = newQuestion.Id, OptionText = question.Option1 },
                        new Option { QuestionID = newQuestion.Id, OptionText = question.Option2 },
                        new Option { QuestionID = newQuestion.Id, OptionText = question.Option3 },
                        new Option { QuestionID = newQuestion.Id, OptionText = question.Option4 }
                    };

                        optionRepo.AddOption(newOption);
                        optionRepo.Save();
                    }

                    return Ok("Added successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest("An error occurred: " + ex.Message);
                }
            }
            return BadRequest("ModelState");
        }
        #endregion

        #region Delete
        [HttpDelete("{QuestionID:int}")]
        public IActionResult DeleteQuestion(int QuestionID)
        {
            Question questionFromDB = questionRepo.GetById(QuestionID);
            if (questionFromDB == null)
            {
                return Ok("Invalid ID");
            }

            questionRepo.Remove(QuestionID);
            questionRepo.Save();
            if(questionFromDB.Type.ToString() == "MCQ")
            {
                optionRepo.Remove(QuestionID);
                optionRepo.Save();
            }
            return Ok("Deleted Succcessfuly");
        }
        #endregion
    }
}
