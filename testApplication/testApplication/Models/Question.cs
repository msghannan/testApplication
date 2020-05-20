using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Quest { get; set; }

        public List<string> ChoiseList = new List<string>();

        public List<string> QuestionsList = new List<string>();

        public Question (int id, string question)
        {
            this.Id = id;
            this.Quest = question;
        }

    }
}
