using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyQuiz.Abstract;

namespace MyQuiz.Models
{
    public class QuizManager:IQuizManager
    {
        static QuizManager instance;
        private QuizContext db = new QuizContext();
        int questionId = 1;
        public bool IsComplete = false;
        public Quiz quiz;

        private QuizManager()
        {            
            quiz = new Quiz();
            quiz.StartTime = DateTime.Now;
            quiz.QuizId = 1;
            quiz.Score = 0 ;
        }

        public static QuizManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuizManager();
                return instance;
            }
        }

        public Question LoadQuiz()
        {
            var question = db.Questions.Find(questionId);
            return question;
        }

        public void SaveAnswer(string answers)
        {
            var question = db.Questions.Include("Answers").Where(x => x.QuestionId == questionId).Single();
            if (question.Answers.AnswerText == answers)
             quiz.Score++;
        }

        public bool MoveToNextQuestion()
        {
            bool canMove = false;

            if ( db.Questions.Count() > questionId)
            {
                questionId++;
                canMove = true;
            }

            return canMove;
        }

        public bool PreviosQuestion()
        {
            bool canMove = false;

            if (questionId > 1)
            {
                questionId--;
                canMove = true;
            }

            return canMove;
        }     
    }
}