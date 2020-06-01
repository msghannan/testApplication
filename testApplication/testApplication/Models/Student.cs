using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
    public class Student : Person
    {
        public int StudentId { get; set; }
        public static implicit operator ObservableCollection<object>(Student v)
        {
            throw new NotImplementedException();
        }
        public bool ShouldSerializeId()
        {
            return false;
        }
    }
}
