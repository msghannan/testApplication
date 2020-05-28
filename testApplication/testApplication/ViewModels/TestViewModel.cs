using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testApplication.Model;
using testApplication.Models;

namespace testApplication.ViewModels
{
    public class TestViewModel
    {
        public List<Question> QuestionList = new List<Question>();
        public List<Test> Test = new List<Test>();
        public List<Answer> AnswerList = new List<Answer>();

        public TestViewModel()
        {

        }


    }
}
