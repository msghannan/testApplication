using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Model
{
    public class Test
    {
        public int TestId { get; set; }
        public string TestName { get; set; }

        public Test (int testId, string testName)
        {
            this.TestId = testId;
            this.TestName = testName;
        }
    }
}
