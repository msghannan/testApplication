using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using testApplication.Model;
using testApplication.ViewModels;

namespace testApplication.Models
{
    public class APIServices
    {
        private static string PostUrl = "https://localhost:44363/api/Tests";
        private static string BaseUrl = "https://localhost:44363/api";
        private static string Accounts = "/Accounts";
        public async Task<Person> LoginAsync(string username, string password)
        {
            Account acc = new Account();
            acc.Username = username;
            acc.Password = password;
            Person p = new Person();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(acc);

                    HttpContent content = new StringContent(json);

                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    var abc = await client.PostAsync(new Uri(BaseUrl + Accounts), content);
                    var result = abc.Content.ReadAsStringAsync().Result;
                    p = JsonConvert.DeserializeObject<Person>(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return p;
        }

        public async Task AddTestAsync(Test t)
        {
            using (HttpClient client = new HttpClient())
            {
                var test = JsonConvert.SerializeObject(t);
                HttpContent httpContent = new StringContent(test);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await client.PostAsync(PostUrl, httpContent);
            }

        }
    }
}
