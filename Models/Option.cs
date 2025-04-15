using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Models
{
    public class Option
    {
        public int Id { get; set; }

        [ForeignKey("Question")]
        public int QuestionID { get; set; }

        public string OptionText { get; set; }

        public Question Question { get; set; }
    }
}
