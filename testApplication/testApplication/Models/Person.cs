using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
   abstract public class Person
    {
      private  string _FirstName;
      private string _LastName;
      private string _Email;
      private string _PhonenNumber;


        public string FirstName
        {
            get { return _FirstName; ; }
            set { _FirstName = value; }
        }

        public string LastNam
        {
            get { return _LastName; ; }
            set { _LastName = value; }
        }
        public string Email
        {
            get { return _Email; ; }
            set { _Email = value; }
        }
        public string PhonenNumber
        {
            get { return _PhonenNumber; ; }
            set { _PhonenNumber = value; }
        }


    }
}
