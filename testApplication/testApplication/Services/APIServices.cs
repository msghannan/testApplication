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
        private static string PostAnswerUrl = "https://localhost:44363/api/Answers";





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


        public async Task <Question> AddQuestonAsync(int a, List<Question> questionList)

        {
            
            
                List<Question> q = questionList;
                for (int i = 0; i < questionList.Count; i++)
                {
                    q[i].TestID = a;
                }

                var quest = JsonConvert.SerializeObject(q);
                HttpContent httpContent = new StringContent(quest);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await httpClient.PostAsync(PostQuestionUrl, httpContent);

                string p = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Question>(p);

               
            
            

           


        }

        //    List<PizzaOrder> temp = new List<PizzaOrder>();

        //        foreach (var piz in pizzalist)
        //        {
        //            temp.Add(new PizzaOrder() { OrderId = a, PizzaId = piz.Id });
        //        }
        //var order = JsonConvert.SerializeObject(temp);
        //HttpContent httpContent = new StringContent(order);
        //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //await httpClient.PostAsync(url + "PizzaOrders", httpContent);
        public async Task AddAnswerAsync(int a, List<Answer> answerList)

        {
            List<Answer> l = answerList;
            for (int i = 0; i < answerList.Count; i++)
            {
                l[i].QuestionId = a;
            }


            var ans = JsonConvert.SerializeObject(answerList);
            HttpContent httpContent = new StringContent(ans);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await httpClient.PostAsync(PostAnswerUrl, httpContent);


        }






    }
}
