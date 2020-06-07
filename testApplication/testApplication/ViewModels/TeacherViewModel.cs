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
        APIServices APIServices;

        private ObservableCollection<Person> _teacherlist;
        public ObservableCollection<Person> Person { get; set; }

        //Listan hämtad från APIServices och fylls med alla lärare
        public ObservableCollection<Person> TeacherList
        {
            get
            {
                _teacherlist = Task.Run(async () => await APIServices.GetAllTeachers()).GetAwaiter().GetResult();
                return _teacherlist;
            }
            set { }
        }
        public TeacherViewModel()
        {
            APIServices = new APIServices();
            httpClient = new HttpClient();
            _teacherlist = new ObservableCollection<Person>();
            Person = new ObservableCollection<Person>();
            Person.Add(App.LoggedInUser);
        }
    }
}
