using System;
using System.Collections.ObjectModel;


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
