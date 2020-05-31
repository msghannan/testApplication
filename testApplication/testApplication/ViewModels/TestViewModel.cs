﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using testApplication.Model;
using testApplication.Models;

namespace testApplication.ViewModels
{
    public class TestViewModel
    {
        HttpClient httpClient;

        public List<Question> QuestionList = new List<Question>();

        //public List<Test> Test = new List<Test>();

        public List<Test> Test = new List<Test>();
        public List<Answer> AnswerList = new List<Answer>();


        public ObservableCollection<Test> TestListFromDatabase { get; set; }

        public ObservableCollection<Question> ActuallyTestsQuestions { get; set; }


        public TestViewModel()
        {
            httpClient = new HttpClient();
            TestListFromDatabase = new ObservableCollection<Test>();

            QuestionList = new List<Question>();

            ActuallyTestsQuestions = new ObservableCollection<Question>();

        }


    }
}
