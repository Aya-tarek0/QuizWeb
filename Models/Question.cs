using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Quiz.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public string CorrectAnswer { get; set; }

        [ForeignKey("QuestionBank")]
        public int? BankID { get; set; }
        public QuestionBank QuestionBank { get; set; }

<<<<<<< HEAD
        public ICollection<Option>? Options { get; set; }
        public ICollection<ExamQuestion>? ExamQuestions { get; set; }
        public ICollection<UserAnswer>? UsersAnswers { get; set; }
=======
        [JsonIgnore]
        public virtual ICollection<Option>? Options { get; set; }
        public virtual ICollection<ExamQuestion>? ExamQuestions { get; set; }
        public virtual ICollection<UserAnswer>? UsersAnswers { get; set; }
>>>>>>> c69ea66bcdfe1a7d6f80024ce1eb28ded3ad042e
    }


}
public enum QuestionType
{
    MCQ,
    TrueOrfalse,
    Complete,
    Written
}

