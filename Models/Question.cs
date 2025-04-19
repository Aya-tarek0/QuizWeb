using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Models
{
    public class Question
    {
        public int Id { get; set; }

        [ForeignKey("QuestionBank")]
        public int? BankID { get; set; }

        public string Text { get; set; }
        public string Type { get; set; }
        public string CorrectAnswer { get; set; }

        public QuestionBank QuestionBank { get; set; }

        public ICollection<Option>? Options { get; set; }
        public ICollection<ExamQuestion>? ExamQuestions { get; set; }
        public ICollection<UserAnswer>? UsersAnswers { get; set; }
    }
}
