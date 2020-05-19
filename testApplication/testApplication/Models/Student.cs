using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
    public class Student: Person
    {
      public int studentID;
      public string studentClass;
       
        public string StudentClass
        {
            get { return studentClass; ; }
            set { studentClass = value; }
        }
        public int StudentId
        {
            get { return studentID; }
            set { studentID = value; }
        }
    }

    
}
