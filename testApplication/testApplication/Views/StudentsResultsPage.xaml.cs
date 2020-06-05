using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class StudentsResultsPage : Page
    {
        private StudentViewModel studentViewModel;
        private StudentsResultsViewModel studentsResultsViewModel;
        private APIServices apiServices;
        private TestViewModel testViewModel;

        public StudentsResultsPage()
        {
            this.InitializeComponent();

            studentViewModel = new StudentViewModel();
            studentsResultsViewModel = new StudentsResultsViewModel();
            apiServices = new APIServices();
            testViewModel = new TestViewModel();

            GetStudentsResults();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        public async void GetStudentsResults()
        {
            var studentsResults = await apiServices.GetStudentsResults();
            foreach (ExamHistoryViewModel results in studentsResults)
            {
                testViewModel.ListOfStudentResults.Add(results);
            }
        }
    }
}
