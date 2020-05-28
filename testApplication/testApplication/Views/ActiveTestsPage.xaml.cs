using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class ActiveTestsPage : Page
    {
        private TestViewModel testViewModel;
        private APIServices apiServices;

        public ActiveTestsPage()
        {
            this.InitializeComponent();

            testViewModel = new TestViewModel();
            apiServices = new APIServices();

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
            

            Test selected = (Test) e.ClickedItem;

            //foreach(Test t in ActiveTestsListView.SelectedItems)
            //{
            //    selected = t;
            //}

            foreach (Question n in selected.QuestionList)
            {
                testViewModel.questions.Add(n);
            }

            this.Frame.Navigate(typeof(WriteTestPage));
        }

        private async void GetTests()
        {
            var tests = await apiServices.GetActiveTests();
            foreach (Test t in tests)
            {
                testViewModel.TestListFromDatabase.Add(t);
            }
        }

    }
}
