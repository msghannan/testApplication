﻿using System;
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

        public Test (int testID, string testName)
        {
            this.TestID = testID;
            this.TestName = testName;
        }
    }
}
