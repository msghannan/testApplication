using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using testApplication.Model;
using testApplication.Models;
using testApplication.ViewModel;
using testApplication.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace testApplication.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateTestPage : Page
    {
        private TestViewModel testViewModel;
        private QuestionViewModel questionViewModel;
        private APIServices aPIServices;
        public Test exam { get; set; }
        public int Number { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        int TotPintsOfQuestions { get { return totPintsOfQuestions; } set { totPintsOfQuestions = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotPintsOfQuestions")); } }
        private int totPintsOfQuestions;

        public CreateTestPage()
        {
            this.InitializeComponent();
            aPIServices = new APIServices();
            testViewModel = new TestViewModel();
            exam = new Test();
            Number = 0;



        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {



            Question question = new Question();
            //question.Answers = testViewModel.AnswerList;

            question.Answers.Add(new Answer(ChoiseTextBox1.Text, (bool)ChoiseCheckBox1.IsChecked));
            question.Answers.Add(new Answer(ChoiseTextBox2.Text, (bool)ChoiseCheckBox2.IsChecked));
            question.Answers.Add(new Answer(ChoiseTextBox3.Text, (bool)ChoiseCheckBox3.IsChecked));
            question.Answers.Add(new Answer(ChoiseTextBox4.Text, (bool)ChoiseCheckBox4.IsChecked));


            //question.Answers.Clear();
            //exam.Questions.Clear();
            question.Quest = QuestionTextbox.Text;

            exam.Questions.Add(question);

            //CountingQuestionsPoints();


            ClearForNewQuestion();

        }

        private async void AddTestButton_Click(object sender, RoutedEventArgs e)
        {
            exam.TestName = TestNameTextbox.Text;
            exam.TestDate = System.DateTime.Now;
            var t = await aPIServices.AddTestAsync(exam);

            //AddTestMessage();

            ClearForNewTest();



        }

        //private void CountingQuestionsPoints()
        //{
        //    int point = int.Parse(QuestionPointInputTextBox.Text);
        //    totPintsOfQuestions += point;

        //    NumberOfPointsInfoTextBlock2.Text = totPintsOfQuestions.ToString();
        //}

        private void ClearForNewQuestion()
        {
            QuestionTextbox.Text = "";

            ChoiseTextBox1.Text = "";
            ChoiseTextBox2.Text = "";
            ChoiseTextBox3.Text = "";
            ChoiseTextBox4.Text = "";

            QuestionPointInputTextBox.Text = "";

        }

        private void ClearForNewTest()
        {
            TestNameTextbox.Text = String.Empty;
            NumberOfPointsInfoTextBlock2.Text = String.Empty;

            ClearForNewQuestion();
        }

        //private async void AddTestMessage()
        //{
        //    CreateNewTestMessageContentDialog c = new CreateNewTestMessageContentDialog();
        //    await c.ShowAsync();
        //}
    }
}
