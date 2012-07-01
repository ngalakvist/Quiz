using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyQuiz.Models
{
     public class AnswerChoice
    {
        public int AnswerChoiceId { get; set; }
        public string Choices { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }

    }
}
