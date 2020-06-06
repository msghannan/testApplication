using System.Collections.Generic;
namespace testApplication.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Quest { get; set; }
        public int QuestionPoint { get; set; }
        public List<Answer> Answers { get; set; }
        public int TestID { get; set; }
        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
