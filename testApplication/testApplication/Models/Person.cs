using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
   abstract public class Person
    {
        private int personID;
        private  string firstName;
        private string lastName;
        private string email;
        private string phoNum;


        public string FirstName
        {
            get { return firstName; ; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; ; }
            set { lastName = value; }
        }
        public string Email
        {
            get { return email; ; }
            set { email = value; }
        }
        public string PhoNumber
        {
            get { return phoNum; ; }
            set { phoNum = value; }
        }
        public int PersonID
        {
            get { return personID; ; }
            set { personID = value; }
        }


    }
}
