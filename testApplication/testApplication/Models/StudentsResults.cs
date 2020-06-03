using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
    public class StudentsResults
    {
        public int ResultId { get; set; }
        public string TestName { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string Grade { get; set; }

        public StudentsResults(int resultId, string testName,string studentFirstName, string studentLastName, string grade)
        {
            this.ResultId = resultId;
            this.TestName = testName;
            this.StudentFirstName = studentFirstName;
            this.StudentLastName = studentLastName;
            this.Grade = grade;
        }

        public StudentsResults()
        {

        }
    }
}
