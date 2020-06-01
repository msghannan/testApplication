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
        public int QuestionPoint { get; set; }
        public List<Answer> Answers { get; set; }
        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
