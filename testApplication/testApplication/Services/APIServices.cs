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

        static HttpClient httpClient = new HttpClient();
        private static string PostUrl = "https://localhost:44363/api/Tests";
        private static string BaseUrl = "https://localhost:44363/api";
        private static string Accounts = "/Accounts";
        private static string PostQuestionUrl = "https://localhost:44363/api/Questions";
            

        

        //HttpClient httpClient;

        //public APIServices()
        //{
        //    httpClient = new HttpClient();
        //}


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


         public async Task <Test> AddTestAsync(Test t)
        {
            using (HttpClient client = new HttpClient())
            {
                var test = JsonConvert.SerializeObject(t);
                HttpContent httpContent = new StringContent(test);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await client.PostAsync(PostUrl, httpContent);

                string p = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Test>(p);

            }

         }


        public  async Task AddQuestonAsync(int id, List<Question> questionList)

        {
        //    List<Question> q = new List<Question>();
        //    Question q1 = new Question();
        //    foreach (var question in questionList)
        //    {
        //        q.Add(new Question(q1.TestId )  ) ;
        //    }

            //Question q = new Question();
            //Test t = new Test();
            //q.TestId = t.TestId;
            //foreach (var question in questionList)
            //{
            //    q.Add(new Question() { TestId = id, Id = question.Id });
            //}



            var quest = JsonConvert.SerializeObject(questionList);
            HttpContent httpContent = new StringContent(quest);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await httpClient.PostAsync(PostQuestionUrl, httpContent);


        }
        public async Task AddAnswerAsync( List<Answer> answerList)

        {


            var ans = JsonConvert.SerializeObject(answerList);
            HttpContent httpContent = new StringContent(ans);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await httpClient.PostAsync(PostQuestionUrl, httpContent);


        }






    }
}
