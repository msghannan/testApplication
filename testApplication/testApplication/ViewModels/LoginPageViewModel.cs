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
        public string PasswordTxt { get; set; }
        public string UsernameTxt { get; set; }

        public ICommand btnLogin{ get; set; }

        public LoginPageViewModel()
        {
            btnLogin = new RelayCommand(LoginAsync);
        }

        //Login fuktionen, här navigeras användaren till rätt sida beroende på om användaren är lärare eller elev
        private async void LoginAsync()
        {
            APIServices _apiService = new APIServices();
            var p = await _apiService.LoginAsync(UsernameTxt, PasswordTxt);
            App.LoggedInUser = p;

            if(p.Id > 0)
            {
                if (p.Role.Teacher == true)
                {
                    var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                    nav.NavigateTo(App.TeacherPage);
                }
                else if (p.Role.Student == true)
                {
                    var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                    nav.NavigateTo(App.StudentPage);
                }
            }

        }
    }
}
