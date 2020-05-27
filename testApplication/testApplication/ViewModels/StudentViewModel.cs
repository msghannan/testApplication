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
    public class StudentViewModel
    {
        HttpClient httpClient;

        string urlGetStudents = "https://localhost:44363/api/Students";

        public ObservableCollection<Person> Person { get; set; }

        public ObservableCollection<Student> StudentList { get; set; }

        public StudentViewModel()
        {
            httpClient = new HttpClient();
            StudentList = new ObservableCollection<Student>();
            Person.Add(App.LoggedInUser);
        }
    }
}
