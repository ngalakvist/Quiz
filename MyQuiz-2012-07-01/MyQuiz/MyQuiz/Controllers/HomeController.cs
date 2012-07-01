using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyQuiz.Models;

namespace MyQuiz.Controllers
{
    public class HomeController : Controller
    {   

        public ActionResult Index()
        {   
            var question = QuizManager.Instance.LoadQuiz();
            return View(question);
        }
        [HttpPost]
        public ActionResult Index(string answer, int questionId)
        {   
            if(QuizManager.Instance.IsComplete) // Prevent score increase if backbutton is clicked and choice made
             return RedirectToAction("ShowResults");     
          
            QuizManager.Instance.SaveAnswer(answer);
            if (QuizManager.Instance.MoveToNextQuestion())
            {
                var question = QuizManager.Instance.LoadQuiz();
                return View(question);
            }
            QuizManager.Instance.IsComplete = true;
            return RedirectToAction("ShowResults");  
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult ShowResults()
        {
            return View(QuizManager.Instance.quiz);
        }
    }
}
