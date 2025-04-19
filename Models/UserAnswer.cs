using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }

        [ForeignKey("Result")]
        public int ResultID { get; set; }

        [ForeignKey("Question")]
        public int QuestionID { get; set; }

        public string UserAnswerText { get; set; }
        public string? IsCorrect { get; set; }

        public double? point { set; get; }

        public ExamResult Result { get; set; }
        public Question Question { get; set; }

    }
}
