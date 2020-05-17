using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace testApplication.ViewModels
{
    public class LoginPageViewModel
    {
        public string PasswordTxt { get; set; }
        public string UsernameTxt { get; set; }

        public ICommand btnLogin{ get; set; }

        public LoginPageViewModel()
        {
            btnLogin = new RelayCommand(Login);
        }

        private void Login()
        {
            //Login backend here
           
        }
    }
}
