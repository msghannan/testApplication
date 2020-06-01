using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Model
{
    public class Test
    {
        public int ID { get; set; }
        public string TestName { get; set; }
        public int MaxPoints { get; set; }
        public DateTime Date { get; set; }
        public List<Question> Questions { get; set; }
        public Test()
        {
            Questions = new List<Question>();
        }
       
    }
}
