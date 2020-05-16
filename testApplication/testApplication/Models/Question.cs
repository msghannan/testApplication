using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Model
{
    public class Question
    {
        public string Quest { get; set; }

        public Question (string question)
        {
            this.Quest = question;
        }

        public static implicit operator ObservableCollection<object>(Question v)
        {
            throw new NotImplementedException();
        }
    }
}
