using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Models
{
    public class AccountLogin
    {
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public char Title { get; set; }

        public AccountLogin (string userName, string password, char title)
        {
            this.UserName = userName;
            this.Password = password;
            this.Title = title;
        }
    }
}
