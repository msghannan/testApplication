using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
    public class AccountLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public AccountLogin (string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }
    }
}
