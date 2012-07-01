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
    public class QuizController : Controller
    {
        private QuizContext db = new QuizContext();

        //
        // GET: /Quiz/

        public ViewResult Index()
        {
            return View(db.Quizs.ToList());
        }

        //
        // GET: /Quiz/Details/5

        public ViewResult Details(int id)
        {
            Quiz quiz = db.Quizs.Find(id);
            return View(quiz);
        }

        //
        // GET: /Quiz/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Quiz/Create

        [HttpPost]
        public ActionResult Create(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Quizs.Add(quiz);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(quiz);
        }
        
        //
        // GET: /Quiz/Edit/5
 
        public ActionResult Edit(int id)
        {
            Quiz quiz = db.Quizs.Find(id);
            return View(quiz);
        }

        //
        // POST: /Quiz/Edit/5

        [HttpPost]
        public ActionResult Edit(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quiz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quiz);
        }

        //
        // GET: /Quiz/Delete/5
 
        public ActionResult Delete(int id)
        {
            Quiz quiz = db.Quizs.Find(id);
            return View(quiz);
        }

        //
        // POST: /Quiz/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Quiz quiz = db.Quizs.Find(id);
            db.Quizs.Remove(quiz);
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