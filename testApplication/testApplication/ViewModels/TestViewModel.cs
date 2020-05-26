using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testApplication.Model;

namespace testApplication.ViewModels
{
    public class TestViewModel
    {
        public List<Question> QuestionList = new List<Question>();
        public List<Test> Test = new List<Test>();

        public TestViewModel()
        {

        }


    }
}
