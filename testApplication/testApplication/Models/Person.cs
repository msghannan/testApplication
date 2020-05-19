using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
   abstract public class Person
    {
        public int Id { get; set; }
        private  string firstName;
        private string lastName;
        private string email;
        private string phoNum;
        private char title;

        public Person(int id, string firstName, string lastName, string email, string phoNum, char title)
        {
            this.Id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoNum = phoNum;
            this.title = title;
        }

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
      

        public char Title
        {
            get { return title; ; }
            set { title = value; }
        }

        public char Title
        {
            get { return title; ; }
            set { title = value; }
        }

    }
}
