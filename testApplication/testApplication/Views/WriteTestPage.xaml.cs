using testApplication.Models;
using testApplication.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
        private Question questionObject;
        private StudentViewModel studentViewModel;
        private Person person;
        private APIServices aPIServices;
        private StudentsResultsViewModel studentsResultsViewModel;

        public StudentsResults studentsResults { get; set; }


        public WriteTestPage()
        {
            this.InitializeComponent();

            testViewModel = new TestViewModel();
            studentViewModel = new StudentViewModel();
            person = new Person();
            aPIServices = new APIServices();
            studentsResults = new StudentsResults();
            studentViewModel = new StudentViewModel();

            //BringTestInfo();
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
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

        private void SignOutButton_Click_1(object sender, RoutedEventArgs e)
        {
             this.Frame.Navigate(typeof(MainPage));
        }

        private async void SendTestButton_Click(object sender, RoutedEventArgs e)
        {
            //studentsResultsViewModel.StudentResultList.Add(new StudentsResults(person.FirstName, person.LastName, testViewModel.Points.ToString()));
            //await aPIServices.PostStudentsResults();
        }

        //private void SendTestButton_Click(object sender, RoutedEventArgs e)
        //{
        //    BringTestInfo();
        //    aPIServices.PostStudentsResults(studentsResults);
        //}

        //public void BringTestInfo()
        //{
        //    studentsResults.Grade = testViewModel.Points.ToString();
        //    studentsResults.StudentFirstName = person.FirstName;
        //    studentsResults.StudentLastName = person.LastName;
        //}


    }
}
