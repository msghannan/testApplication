using System;
using System.Collections.Generic;
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

        public CreateTestPage()
        {
            this.InitializeComponent();

            testViewModel = new TestViewModel();
            questionViewModel = new QuestionViewModel();

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
            //skapa Question objekht

            Question Q1 = new Question();

            Q1.Quest = QuestionTextbox.Text;
            Q1.QuestionPoint = int.Parse(QuestionPointInputTextBox.Text);

            Q1.AnswerList.Add(new Answer(ChoiseTextBox1.Text, (bool)ChoiseCheckBox1.IsChecked));
            Q1.AnswerList.Add(new Answer(ChoiseTextBox2.Text, (bool)ChoiseCheckBox2.IsChecked));
            Q1.AnswerList.Add(new Answer(ChoiseTextBox3.Text, (bool)ChoiseCheckBox3.IsChecked));
            Q1.AnswerList.Add(new Answer(ChoiseTextBox4.Text, (bool)ChoiseCheckBox4.IsChecked));

            testViewModel.QuestionList.Add(Q1);

            CountingQuestionsPoints();

        }

        private void AddTestButton_Click(object sender, RoutedEventArgs e)
        {
            Test T1 = new Test();

            T1.TestName = TestNameTextbox.Text;
            T1.MaxPoints = int.Parse(NumberOfPointsInfoTextBlock2.Text);

            T1.QuestionList = testViewModel.QuestionList;

            testViewModel.TestList.Add(T1);

        }

        private void CountingQuestionsPoints()
        {
            int totPoints = 0;
            int questPoint = 0;

            QuestionPointInputTextBox.Text = totPoints.ToString();

            totPoints += questPoint;

            NumberOfPointsInfoTextBlock2.Text = questPoint.ToString();
            
        }


    }
}
