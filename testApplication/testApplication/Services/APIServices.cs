using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using testApplication.ViewModels;

namespace testApplication.Models
{
    public class APIServices
    {

        static HttpClient httpClient = new HttpClient();
        private static string PostUrl = "https://localhost:44363/api/Tests";
        private static string urlGetStudentsResults = "https://localhost:44363/api/StudentsResults";
        private static string BaseUrl = "https://localhost:44363/api";
        private static string Accounts = "/Accounts";
        private static string PostQuestionUrl = "https://localhost:44363/api/Questions";
        private static string PostAnswerUrl = "https://localhost:44363/api/Answers";
        private static string PostStudentsResultsUrl = "https://localhost:44363/api/StudentsResults";
        private static string GetAllPeopleUrl = "https://localhost:44363/api/People";
        private static string DeleteUrl = "https://localhost:44363/api/tests/";


        //Login funktionen
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

        //Skapa test
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

        //Lägga till fråga i test
        public async Task <Question> AddQuestonAsync(int a, List<Question> questionList)
        {
                List<Question> q = questionList;

                var quest = JsonConvert.SerializeObject(q);
                HttpContent httpContent = new StringContent(quest);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await httpClient.PostAsync(PostQuestionUrl, httpContent);

                string p = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Question>(p);

        }

        //Hämta alla aktiva prov
        public async Task<ObservableCollection<Test>> GetAllExamsAsync()
        {
            var jsonTests = await httpClient.GetStringAsync(BaseUrl + "/Tests");

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var tests = JsonConvert.DeserializeObject<ObservableCollection<Test>>(jsonTests, settings);

            return tests;
        }

        //Hämta elevernas resultat
        public async Task<ObservableCollection<ExamHistoryViewModel>> GetStudentsResults()
        {
            var studentsResults = await httpClient.GetStringAsync(urlGetStudentsResults);

            var results = JsonConvert.DeserializeObject<ObservableCollection<ExamHistoryViewModel>>(studentsResults);

            return results;
        }

        //Skicka elevernas resultat
        public async void PostStudentsResults(StudentsResults results)
        {
            var result = JsonConvert.SerializeObject(results);
            HttpContent httpContent = new StringContent(result);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var responseStatus = await httpClient.PostAsync(PostStudentsResultsUrl, httpContent);
        }

        //Hämta alla elever
        public async Task<ObservableCollection<Person>> GetAllStudents()
        {
            char student = 'S';
            var people = await httpClient.GetStringAsync(GetAllPeopleUrl);

            var allPeople = JsonConvert.DeserializeObject<ObservableCollection<Person>>(people);

            ObservableCollection<Person> templist = new ObservableCollection<Person>();

            foreach (Person p in allPeople)
            {
                if (p.Title == student)
                {
                    templist.Add(p);
                }
            }
            return templist;
        }

        //Hämta alla lärare
        public async Task<ObservableCollection<Person>> GetAllTeachers()
        {
            char teacher = 'T';
            var people = await httpClient.GetStringAsync(GetAllPeopleUrl);

            var allPeople = JsonConvert.DeserializeObject<ObservableCollection<Person>>(people);

            ObservableCollection<Person> templist = new ObservableCollection<Person>();

            foreach (Person p in allPeople)
            {
                if (p.Title == teacher)
                {
                    templist.Add(p);
                }
            }
            return templist;
        }

        public async Task DeleteTestAsync(Test test)
        {
            var httpClient = new System.Net.Http.HttpClient();
            await httpClient.DeleteAsync(DeleteUrl + test.ID);
        }

        public async Task<ObservableCollection<Test>> GetTestssAsync()
        {
            TestViewModel testViewModel = new TestViewModel();
            var jsonDeleteTest = await httpClient.GetStringAsync(DeleteUrl);
            testViewModel.TestListFromDatabase = JsonConvert.DeserializeObject<ObservableCollection<Test>>(jsonDeleteTest);
            return testViewModel.TestListFromDatabase;
        }
    }
}
