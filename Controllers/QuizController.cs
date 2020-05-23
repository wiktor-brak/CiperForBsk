using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CiperForBsk.Models;
using Microsoft.AspNetCore.Mvc;

namespace CiperForBsk.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index(Message message)
        {      
            return View();
        }

        public IActionResult Q1(Message message)
        {
            if(!String.IsNullOrEmpty(message.Msg))
            {
                if (message.Msg == "8")
                {
                    return RedirectToAction("Q2");
                }
            }
            return View();
        }
        public IActionResult Q2()
        {
            return View();
        }
        public IActionResult Q3()
        {
            return View();
        }
        public IActionResult Q4()
        {
            return View();
        }
        public IActionResult Q5()
        {
            return View();
        }
        public IActionResult Q6()
        {
            return View();
        }
    }
}