using GalaSoft.MvvmLight;
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
using testApplication.Models;

namespace testApplication.ViewModels
{
    public class TestViewModel : ViewModelBase
    {
    
        public ObservableCollection<Question> QuestionList = new ObservableCollection<Question>();
        public ObservableCollection<ExamHistoryViewModel> ListOfStudentResults = new ObservableCollection<ExamHistoryViewModel>();

        public ICommand NextBtnCmd { get; set; }
        public ICommand FinishExamCmd { get; set; }
        public bool Answer1IsChecked { get; set; }
        public bool Answer2IsChecked { get; set; }
        public bool Answer3IsChecked { get; set; }
        public bool Answer4IsChecked { get; set; }
        public int Counter { get; set; }
        public int Points { get; set; }
        public string _numberOfCurrentlyQuestion { get; set; }
        public string NumberOfCurrentlyQuestion

        {
            get { return _numberOfCurrentlyQuestion;  }
            set { _numberOfCurrentlyQuestion = value; }
        }
        public Test CurrentlyExam = new Test();
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
            FinishExamCmd = new RelayCommand(FinishExam);
            Counter = 1;
            Points = 0;
            TestListFromDatabase = new ObservableCollection<Test>();
            ListOfStudentResults = new ObservableCollection<ExamHistoryViewModel>();

            CurrentlyQuestion = new Question();
            if(QuestionList?.Count > 0)
            {
                CurrentlyQuestion = QuestionList[Counter];
                NumberOfCurrentlyQuestion = "Fråga nr: " + (Counter + 1) + " / " + QuestionList.Count;
                RaisePropertyChanged(nameof(NumberOfCurrentlyQuestion));
            }
        }

        private void FinishExam()
        {
            APIServices api = new APIServices();
            CalculatePoints();
            double a = Points;
            string grade;


            if((a / CurrentlyExam.MaxPoints) > 0.75)
            {
                grade = "Väl Godkänd";
            }
            else if ((a / CurrentlyExam.MaxPoints) > 0.5)
            {
                grade = "Godkänd";
            }
            else
            {
                grade = "Icke Godkänd";
            }


            api.PostStudentsResults(new StudentsResults()
            {
                Grade = grade,
                TestId = CurrentlyExam.ID,
                PersonId = App.LoggedInUser.Id
            });

        }

        //Funktionen bakom knappen (nästa fråga) när eleven svarar på provets frågor
        private void NextQuestion()
        {

            if (Counter < QuestionList.Count)
            {
                CalculatePoints();
                CurrentlyQuestion = QuestionList[Counter];
                NumberOfCurrentlyQuestion = "Fråga nr: " + (Counter + 1) + " / " + QuestionList.Count;
                RaisePropertyChanged(nameof(CurrentlyQuestion));
                RaisePropertyChanged(nameof(NumberOfCurrentlyQuestion));
                Counter++;
            }
            else
            {
                FinishExam();
            }
        }

        //Räknar elevens poäng
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
        internal void RemoveTest(Test test)
        {
            TestListFromDatabase.Remove(test);
        }
    }
}
