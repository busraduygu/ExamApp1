using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int rlt_Exam_Id { get; set; }

        [ForeignKey(nameof(rlt_Exam_Id))]
        public Exam Exam { get; set; }

        public int? rlt_Correct_Option_Id { get; set; }

        [ForeignKey(nameof(rlt_Correct_Option_Id))]
        public Option CorrectOption { get; set; }

        public ICollection<Option> Options { get; set; }
    }
}
