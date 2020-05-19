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

        public Test (int testId, string testName)
        {
            this.TestID = testId;
            this.TestName = testName;
        }
    }
}
