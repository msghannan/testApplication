using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
    class Student: Person
    {
      public int _StudentId;
      public string _Klass;
       
        public string Klass
        {
            get { return _Klass; ; }
            set { _Klass = value; }
        }
        public int StudentId
        {
            get { return _StudentId; }
            set { _StudentId = value; }
        }
    }

    
}
