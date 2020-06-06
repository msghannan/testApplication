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
    public sealed partial class ActiveTestsPage : Page
    {
        private TestViewModel testViewModel;
        private APIServices apiServices;
        private StudentsResultsViewModel studentsResultsViewModel;
        private WriteTestPage writeTestPage;

        public ActiveTestsPage()
        {
            this.InitializeComponent();

            testViewModel = new TestViewModel();
            apiServices = new APIServices();
            studentsResultsViewModel = new StudentsResultsViewModel();
            writeTestPage = new WriteTestPage();

            GetTests();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ActiveTestsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Test selectedItem = (Test) e.ClickedItem;

            foreach (Question quest in selectedItem.Questions)
            {
                testViewModel.QuestionList.Add(quest);
            }

            this.Frame.Navigate(typeof(WriteTestPage),(Test)selectedItem);
        }

        public async void GetTests()
        {
            var tests = await apiServices.GetAllExamsAsync();
            foreach (Test t in tests)
            {
                testViewModel.TestListFromDatabase.Add(t);
            }
        }

    }
}
