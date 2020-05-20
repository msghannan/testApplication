using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
    public class Teacher : Person
    {
        public int TeacherId { get; set; }

        public Teacher(int teacherId, int id, string firstName, string lastName, string email, string phoNum, char title) : base(id, firstName, lastName, email, phoNum, title)
        {
            this.TeacherId = teacherId;
        }
    }
}
