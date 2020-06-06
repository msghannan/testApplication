using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using testApplication.Models;
using testApplication.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace testApplication.ViewModels
{
    public class LoginPageViewModel
    {
        //public INavigationService _navigationService { get; set; }
        public string PasswordTxt { get; set; }
        public string UsernameTxt { get; set; }

        public ICommand btnLogin{ get; set; }

        public LoginPageViewModel()
        {
            //_navigationService = navigationService;
            btnLogin = new RelayCommand(LoginAsync);
        }
        private async void LoginAsync()
        {
            //Login backend here
            APIServices _apiService = new APIServices();
            var p = await _apiService.LoginAsync(UsernameTxt, PasswordTxt);
            App.LoggedInUser = p;

            if(p.Role.Teacher == true)
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.NavigateTo(App.TeacherPage);
            }
            else if(p.Role.Student == true)
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.NavigateTo(App.StudentPage);
            }
           
        }
    }
}
