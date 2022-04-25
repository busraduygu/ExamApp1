using ExamApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserExamPage()
        {
            return View();
            
        }
        public IActionResult UserExamDetailPage()
        {

            return View();
        }
    }
    
}
