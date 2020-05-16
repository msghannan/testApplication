using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
   public class Teacher: Person
   {
        public int _TeacherId;

        public int TeacherId
        {
            get { return _TeacherId; }
            set { _TeacherId = value; }
        }
    }
}
