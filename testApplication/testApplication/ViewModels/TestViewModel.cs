﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using testApplication.Model;
using testApplication.Models;

namespace testApplication.ViewModels
{
    public class TestViewModel : ViewModelBase
    {
        HttpClient httpClient;

        public ObservableCollection<Question> QuestionList = new ObservableCollection<Question>();

        public ICommand NextBtnCmd { get; set; }

        public bool Answer1IsChecked { get; set; }
        public bool Answer2IsChecked { get; set; }
        public bool Answer3IsChecked { get; set; }
        public bool Answer4IsChecked { get; set; }



        public int Counter { get; set; }
        public int Points { get; set; }

        public List<Test> Test = new List<Test>();
        public List<Answer> AnswerList = new List<Answer>();


        public ObservableCollection<Test> TestListFromDatabase { get; set; }


        public Question _CurrentlyQuestion { get; set; }
        public Question CurrentlyQuestion
        {
            get { return _CurrentlyQuestion; }
            set { _CurrentlyQuestion = value; }
        }


        public TestViewModel()
        {
            NextBtnCmd = new RelayCommand(NextQuestion);
            Counter = 0;
            Points = 0;
            TestListFromDatabase = new ObservableCollection<Test>();
            //QuestionList = new List<Question>();

            //CurrentTestQuestions = new ObservableCollection<Question>();
            CurrentlyQuestion = new Question();
            if(QuestionList?.Count > 0)
            {
                CurrentlyQuestion = QuestionList[Counter];

            }
        }

        private void NextQuestion()
        {
            Counter++;
            CalculatePoints();
            if (Counter < QuestionList.Count)
            {
                CurrentlyQuestion = QuestionList[Counter];
                RaisePropertyChanged(nameof(CurrentlyQuestion));
            }
        }

        private void CalculatePoints()
        {
            int dividePoint = CurrentlyQuestion.Answers.Where(x => x.CorrectAnswer == true).Count();

            if(Answer1IsChecked && CurrentlyQuestion.Answers[0].CorrectAnswer)
            {
                Points += (CurrentlyQuestion.QuestionPoint / dividePoint);
            }
            if(Answer2IsChecked && CurrentlyQuestion.Answers[1].CorrectAnswer)
            {
                Points += (CurrentlyQuestion.QuestionPoint / dividePoint);
            }
            if(Answer3IsChecked && CurrentlyQuestion.Answers[2].CorrectAnswer)
            {
                Points += (CurrentlyQuestion.QuestionPoint / dividePoint);
            }
            if(Answer4IsChecked && CurrentlyQuestion.Answers[3].CorrectAnswer)
            {
                Points += (CurrentlyQuestion.QuestionPoint / dividePoint);
            }
        }
    }
}
