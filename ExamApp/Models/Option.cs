using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApp.Models
{
    public class Option
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int rlt_Question_Id { get; set; }

        [ForeignKey(nameof(rlt_Question_Id))]
        public Question Question { get; set; }
    }
}
