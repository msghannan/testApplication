using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testApplication.Models;

namespace testApplication.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Quest { get; set; }

        public int TestId { get; set; }
        public int QuestionPoint { get; set; }

        public List<Answer> AnswerList = new List<Answer>();

        public Question (string question, int questionPoint)
        {
            this.Quest = question;
            this.QuestionPoint = questionPoint;
        }

        public Question()
        {

        }
        

    }
}
