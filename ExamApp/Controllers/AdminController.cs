using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Helpers;
using ExamApp.Models;
using ExamApp.SqliteData;
using ExamApp.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace ExamApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateExam()
        {
            HelperMethods helperMethods = new HelperMethods();
            var dataList = helperMethods.GetQuestionTitleAndTextFromWired();
            MultiModel multiModel = new MultiModel();
            multiModel.Datas = dataList;
            return View(multiModel);

        }
        [HttpGet]
        [Route("/admin/getQuestionText/{questionId}")]
        public JsonResult GetQuestionText(int questionId)
        {
            HelperMethods helperMethods = new HelperMethods();
            var dataList = helperMethods.GetQuestionTitleAndTextFromWired();
            var questionText = dataList.FirstOrDefault(q => q.Id == questionId)?.Text;

            return Json(new { questionText });
        }

        //Oluşturulan soruları ve sınav bilgilerini veritabanına kaydetme
        [HttpPost]
        public IActionResult AddExam(ExamViewModel viewModel)
        {

            //Create Exam
            var db = new Context();
            var exam = new Exam()
            {
                Title = viewModel.Title,
                Text = viewModel.Text,
                rlt_Creator_Admin_Id = 1
            };
            exam.Questions = new List<Question>();

            foreach (var item in viewModel.Questions)
            {
                var question = new Question
                {
                    rlt_Correct_Option_Id = item.rlt_Correct_Answer_Id,
                    Text = item.Text
                };
                question.Options = new List<Option>();

                foreach (var option in item.Answers)
                {
                    question.Options.Add(new Option
                    {
                        Text = option.Text
                    });
                }

                exam.Questions.Add(question);
            }

            db.Exams.Add(exam);
            var result = db.SaveChanges() == 1;
            return Json(new { result });
        }
        public IActionResult CreateQuestion(Question question)
        {
            //Create Question
            Question questionItem = new Question();
            //questionItem = 
            //List<Question> questionList = new List<Question>();

            return View();
        }
    }
}
