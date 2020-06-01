using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool CorrectAnswer { get; set; }
        public int QuestionId { get; set; }

        public Answer(string ans, bool correctAnswer)
        {
            this.AnswerText = ans;
            this.CorrectAnswer = correctAnswer;
        }

        public Answer()
        {

        }
    }
}
