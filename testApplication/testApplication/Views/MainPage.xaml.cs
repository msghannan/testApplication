using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using testApplication.ViewModel;
using testApplication.ViewModels;
using testApplication.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace testApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private LoginPageViewModel loginPageViewModel;
        private QuestionViewModel questionViewModel;
        private PersonViewModel personViewModel;
        private TestViewModel testViewModel;
        private StudentViewModel studentViewModel;
        private TeacherViewModel teacherViewModel;

        public MainPage()
        {
            this.InitializeComponent();

            loginPageViewModel = new LoginPageViewModel();
            questionViewModel = new QuestionViewModel();
            personViewModel = new PersonViewModel();
            testViewModel = new TestViewModel();
            studentViewModel = new StudentViewModel();
            teacherViewModel = new TeacherViewModel();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TeacherPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StudentPage));
        }
    }
}
