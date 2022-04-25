using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int rlt_Created_Exam_Id { get; set; }
    }
}
