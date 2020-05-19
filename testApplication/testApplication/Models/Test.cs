using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Model
{
    public class Test
    {
        public int TestID { get; set; }
        public string TestName { get; set; }
        public int MaxPoints { get; set; }
        public DateTime TestDate { get; set; }

        public Test (int testId, string testName, int maxPoints, DateTime testDate)
        {
            this.TestID = testId;
            this.TestName = testName;
            this.MaxPoints = maxPoints;
            this.TestDate = testDate; 
        }
    }
}
