using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using testApplication.Model;
using testApplication.Models;
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
    public sealed partial class WriteTestPage : Page
    {
        private TestViewModel testViewModel;
        public Question questionObject;

        public WriteTestPage()
        {
            this.InitializeComponent();

            testViewModel = new TestViewModel();
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var selectedItem = (Test)e?.Parameter;

            foreach (Question question in selectedItem.Questions)
            {
                testViewModel.QuestionList.Add(question);
                questionObject = question;
                foreach (Answer answer in questionObject.Answers)
                {
                    testViewModel.AnswerList.Add(answer);
                }
            }

            testViewModel.CurrentlyQuestion = testViewModel.QuestionList[0];
        }
    }
}
