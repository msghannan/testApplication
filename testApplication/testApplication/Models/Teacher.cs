using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
   public class Teacher: Person
   {
        public int teacherId;

        public int TeacherId
        {
            get { return teacherId; }
            set { teacherId = value; }
        }
    }
}
