using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Quiz.DTO;
using Quiz.Interface;
using Quiz.Models;

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : ControllerBase
    {
        IExamResultRepository examResultRepository;

        public ExamResultController(IExamResultRepository examResultRepository)
        {
            this.examResultRepository = examResultRepository;
        }


        #region Get All ExamResults To Creator

        [HttpGet("{ExamID:int}")]

        public IActionResult GetAll(int ExamID, string UserId)

        {
            List<ResultDTO> examResults = examResultRepository.GetAllResultsForExam()
                                                              .Where(e => e.ExamID == ExamID && e.CreatorID == UserId)
                                                              .ToList();

            return Ok(examResults);


        }
        #endregion


        #region Get Results To User

        [HttpGet("User-Results/{UserID}")]
        public IActionResult GetResultsByUserId(string UserID)
        {
            List<ResultDTO> result = examResultRepository.GetResultByUserId().Where(e => e.userid == UserID).ToList();

            return Ok(result);
        }

        #endregion


        #region Get One Result To User
        [HttpGet("OneResult/{UserID}")]
        public IActionResult GetResultByUser(string UserID, int ExamID)
        {
            ResultDTO result = examResultRepository.GetOneResultByUserID(UserID, ExamID);
            return Ok(result);
        }

        #endregion


        #region Add Result
        [HttpPost]

        public IActionResult AddResult([FromBody] ResultAddDto NewResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            ExamResult examResult = new ExamResult
            {
                ExamID = NewResult.ExamID,
                UserID = NewResult.userid,
                Date = NewResult.date,


            };
            examResultRepository.Add(examResult);
            examResultRepository.Save();

            return Ok(examResult);

        }
        #endregion


        #region Update Result
        [HttpPut]
        public IActionResult UpdateResult(int id, [FromBody] ResultUpdateDTO NewResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = examResultRepository.GetById(id);
            if (result == null)
            {
                return NotFound("Result Not Found");
            }

            result.Score = NewResult.score;
            result.FeedBack = NewResult.FeedBack;



            examResultRepository.Update(id, result);
            examResultRepository.Save();

            return Ok(result);
        }
        #endregion



        #region Delete Result
        [HttpDelete("{id:int}")]
        public IActionResult DeleteResult(int id)
        {
            var result = examResultRepository.GetById(id);
            if (result == null)
            {
                return NotFound($"Result with ID {id} not found.");
            }

            examResultRepository.Remove(id);
            examResultRepository.Save();

            return NoContent();
        }
        #endregion




    }
}
