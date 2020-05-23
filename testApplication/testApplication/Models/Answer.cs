using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Ans { get; set; }
        public bool CorrectAnswer { get; set; }
        public int QuestionId { get; set; }
    }
}
