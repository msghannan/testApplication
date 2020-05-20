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

        public ObservableCollection<Student> StudentList { get; set; }

        public StudentViewModel()
        {
            httpClient = new HttpClient();
            StudentList = new ObservableCollection<Student>();
            GetStudents();
        }

        public async void GetStudents()
        {
            var jsonGetStudent = await httpClient.GetStringAsync(urlGetStudents);

            var student = JsonConvert.DeserializeObject<ObservableCollection<Student>>(jsonGetStudent);

            foreach (Student a in student)
            {
                StudentList.Add(a);
            }
        }
    }
}
