using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
    public class Student : Person
    {
        public int StundentId { get; set; }
        public string Grade { get; set; }

        public Student (int studentId, string grade, int id, string firstName, string lastName, string email, string phoNum, char title) :base (id, firstName, lastName, email, phoNum, title)
        {
            this.StundentId = studentId;
            this.Grade = grade;
        }
    }
}
