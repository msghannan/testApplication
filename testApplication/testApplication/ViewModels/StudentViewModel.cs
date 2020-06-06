using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using testApplication.Models;

namespace testApplication.ViewModels
{
    public class StudentViewModel
    {
        HttpClient httpClient;
        APIServices APIServices;

        private ObservableCollection<Person> _studentlist;
        public ObservableCollection<Person> Person { get; set; }

        //Listan hämtad från APIServices och fylls med alla studenter
        public ObservableCollection<Person> StudentList { get 
            {
                _studentlist = Task.Run(async () => await APIServices.GetAllStudents()).GetAwaiter().GetResult();
                
                return _studentlist;
            }

            set { } }

        public StudentViewModel()
        {
            APIServices = new APIServices();
            _studentlist = new ObservableCollection<Person>();
            httpClient = new HttpClient();
            Person = new ObservableCollection<Person>();
            Person.Add(App.LoggedInUser); 
        }
    }
}
