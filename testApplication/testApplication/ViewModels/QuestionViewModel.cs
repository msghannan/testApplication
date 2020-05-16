using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testApplication.Model;

namespace testApplication.ViewModel
{
    public class QuestionViewModel
    {
        public ObservableCollection<Question> Choises { get; set; }

        public QuestionViewModel ()
        {

        }
    }
}
