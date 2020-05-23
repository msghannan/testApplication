using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
    public class Student : Person
    {
        public int StudentId { get; set; }

        public Student (/*int StudentId, string grade, int id, string firstName, string lastName, string email, string phoNum, char title) :base (id, firstName, lastName, email, phoNum, title*/)
        {
            //this.StudentId  = Id;
            //this.Grade = grade;
        }

        public static implicit operator ObservableCollection<object>(Student v)
        {
            throw new NotImplementedException();
        }

        public bool ShouldSerializeId()
        {
            return false;
        }
    }
}
