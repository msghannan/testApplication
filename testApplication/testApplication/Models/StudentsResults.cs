using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
    public class StudentsResults
    {
        public int Id { get; set; }
        public string Grade { get; set; }
        public int PersonId { get; set; }
        public int TestId { get; set; }

        //public StudentsResults(int Id, string grade, int personId, int testId)
        //{
        //    this.Id = Id;
        //    this.Grade = grade;
        //    this.PersonId = personId;
        //    this.TestId = testId;
        //}

        public StudentsResults()
        {

        }
    }
}
