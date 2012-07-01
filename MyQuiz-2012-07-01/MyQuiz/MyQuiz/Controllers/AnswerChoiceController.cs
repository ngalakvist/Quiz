using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyQuiz.Models;

namespace MyQuiz.Controllers
{ 
    public class AnswerChoiceController : Controller
    {
        private QuizContext db = new QuizContext();

        //
        // GET: /AnswerChoice/

        public ViewResult Index()
        {
            var answerchoices = db.AnswerChoices.Include(a => a.Question);
            return View(answerchoices.ToList());
        }

        //
        // GET: /AnswerChoice/Details/5

        public ViewResult Details(int id)
        {
            AnswerChoice answerchoice = db.AnswerChoices.Find(id);
            return View(answerchoice);
        }

        //
        // GET: /AnswerChoice/Create

        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionText");
            return View();
        } 

        //
        // POST: /AnswerChoice/Create

        [HttpPost]
        public ActionResult Create(AnswerChoice answerchoice)
        {
            if (ModelState.IsValid)
            {
                db.AnswerChoices.Add(answerchoice);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionText", answerchoice.QuestionId);
            return View(answerchoice);
        }
        
        //
        // GET: /AnswerChoice/Edit/5
 
        public ActionResult Edit(int id)
        {
            AnswerChoice answerchoice = db.AnswerChoices.Find(id);
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionText", answerchoice.QuestionId);
            return View(answerchoice);
        }

        //
        // POST: /AnswerChoice/Edit/5

        [HttpPost]
        public ActionResult Edit(AnswerChoice answerchoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answerchoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionText", answerchoice.QuestionId);
            return View(answerchoice);
        }

        //
        // GET: /AnswerChoice/Delete/5
 
        public ActionResult Delete(int id)
        {
            AnswerChoice answerchoice = db.AnswerChoices.Find(id);
            return View(answerchoice);
        }

        //
        // POST: /AnswerChoice/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            AnswerChoice answerchoice = db.AnswerChoices.Find(id);
            db.AnswerChoices.Remove(answerchoice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}