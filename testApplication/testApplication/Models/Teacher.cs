using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Firstname { get; set; }

        public Teacher(int teacherid, string firstname)
        {
            this.TeacherId = teacherid;
            this.Firstname = firstname;
        }
    }
}
