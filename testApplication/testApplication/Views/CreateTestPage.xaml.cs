using System;
using System.ComponentModel;
using testApplication.Models;
using testApplication.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace testApplication.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateTestPage : Page
    {
        private TestViewModel testViewModel;
        private APIServices aPIServices;

        public Test exam { get; set; }
        public int Number { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        int TotPointsOfQuestions { get { return totPointsOfQuestions; } set { totPointsOfQuestions = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotPointsOfQuestions")); } }
        private int totPointsOfQuestions;

        int NumberOfQuestions { get { return numberOfQuestions; } set { numberOfQuestions = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumberOfQuestions")); } }
        private int numberOfQuestions = 0;

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
            AddQuestion();

            CountingNumberOfQuestions();

            CountingQuestionsPoints();

            ClearForNewQuestion();
        }

        private async void AddTestButton_Click(object sender, RoutedEventArgs e)
        {
            AddQuestion();
            CountingQuestionsPoints();
            CountingNumberOfQuestions();

            exam.TestName = TestNameTextbox.Text;
            exam.Date = System.DateTime.Now;
            exam.MaxPoints = int.Parse(NumberOfPointsInfoTextBlock2.Text);
            exam.NumberOfQuestions = int.Parse(NumberOfWuestionsInfoTextBlock2.Text);
            var t = await aPIServices.AddTestAsync(exam);

            AddTestMessage();

            ClearForNewTest();
        }

        private void AddQuestion()
        {
            Question question = new Question();

            question.Answers.Add(new Answer(ChoiseTextBox1.Text, (bool)ChoiseCheckBox1.IsChecked));
            question.Answers.Add(new Answer(ChoiseTextBox2.Text, (bool)ChoiseCheckBox2.IsChecked));
            question.Answers.Add(new Answer(ChoiseTextBox3.Text, (bool)ChoiseCheckBox3.IsChecked));
            question.Answers.Add(new Answer(ChoiseTextBox4.Text, (bool)ChoiseCheckBox4.IsChecked));

            question.QuestionPoint = int.Parse(QuestionPointInputTextBox.Text);
            question.Quest = QuestionTextbox.Text;

            exam.Questions.Add(question);
        }

        private void CountingNumberOfQuestions()
        {
            numberOfQuestions += 1;

            NumberOfWuestionsInfoTextBlock2.Text = numberOfQuestions.ToString();
        }
        private void CountingQuestionsPoints()
        {
            int point = int.Parse(QuestionPointInputTextBox.Text);
            totPointsOfQuestions += point;

            NumberOfPointsInfoTextBlock2.Text = totPointsOfQuestions.ToString();
        }

        private void ClearForNewQuestion()
        {
            QuestionTextbox.Text = String.Empty;

            ChoiseTextBox1.Text = String.Empty;
            ChoiseTextBox2.Text = String.Empty;
            ChoiseTextBox3.Text = String.Empty;
            ChoiseTextBox4.Text = String.Empty;

            QuestionPointInputTextBox.Text = String.Empty;
        }

        private void ClearForNewTest()
        {
            TestNameTextbox.Text = String.Empty;
            NumberOfPointsInfoTextBlock2.Text = String.Empty;

            ClearForNewQuestion();
        }

        private async void AddTestMessage()
        {
            CreateNewTestMessageContentDialog c = new CreateNewTestMessageContentDialog();
            await c.ShowAsync();
        }

        private async void DisplayNoWifiDialog()
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "No wifi connection",
                Content = "Check connection and try again.",
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();
        }
    }
}
