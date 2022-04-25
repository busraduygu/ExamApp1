using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApp.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int rlt_Creator_Admin_Id { get; set; }

        [ForeignKey(nameof(rlt_Creator_Admin_Id))]
        public Admin CreatorAdmin { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<Question> Questions { get; set; }

    }
}
