using System;
using System.Collections.Generic;

namespace testApplication.Models
{
    public class Test
    {
        public int ID { get; set; }
        public string TestName { get; set; }
        public int MaxPoints { get; set; }
        public int NumberOfQuestions { get; set; }
        public DateTime Date { get; set; }
        public List<Question> Questions { get; set; }
        public Test()
        {
            Questions = new List<Question>();
        }
       
    }
}
