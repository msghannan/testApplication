using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Model
{
    public class Test
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public int MaxPoints { get; set; }
        public DateTime TestDate { get; set; }

        public List<Question> QuestionList = new List<Question>();

        public Test (int testId, string testName, int maxPoints, DateTime testDate)
        {
            this.TestId = testId;
            this.TestName = testName;
            this.MaxPoints = maxPoints;
            this.TestDate = testDate; 
        }

        public Test()
        {

        }
    }
}
