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
    public sealed partial class DeleteTestPage : Page
    {
        private TestViewModel testViewModel;
        private APIServices aPIServices;

        public DeleteTestPage()
        {
            this.InitializeComponent();
            aPIServices = new APIServices();

            testViewModel = new TestViewModel();
            Get();
        }
        public async void Get()
        {
            Test.ItemsSource = await aPIServices.GetTestssAsync() ;
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
         {
            var select = Test.SelectedItems;
            foreach (Test test in select)
            {


                testViewModel.RemoveTest(test);
                await aPIServices.DeleteTestAsync(test);

            }
        }
    }
}
