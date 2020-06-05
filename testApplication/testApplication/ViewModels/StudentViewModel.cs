using System.Collections.ObjectModel;
using System.Net.Http;
using testApplication.Models;

namespace testApplication.ViewModels
{
    public class StudentViewModel
    {
        HttpClient httpClient;

        public ObservableCollection<Person> Person { get; set; }

        public ObservableCollection<Student> StudentList { get; set; }

        public StudentViewModel()
        {
            httpClient = new HttpClient();
            Person = new ObservableCollection<Person>();
            Person.Add(App.LoggedInUser); 
        }
    }
}
