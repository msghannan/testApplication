using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using testApplication.Models;

namespace testApplication.ViewModels
{
    public class TeacherViewModel
    {
        HttpClient httpClient;

        string urlGetTeachers = "https://localhost:44363/api/Teachers";

        public ObservableCollection<Person> Person { get; set; }



        public TeacherViewModel()
        {
            httpClient = new HttpClient();
            Person = new ObservableCollection<Person>();
            Person.Add(App.LoggedInUser);

        }



    }
}
