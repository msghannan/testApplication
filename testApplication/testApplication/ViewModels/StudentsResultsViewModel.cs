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
    class StudentsResultsViewModel
    {
        HttpClient httpClient;

        string urlGetStudentsResults = "https://localhost:44363/api/StudentsResults";

        public ObservableCollection<StudentsResults> StudentResultList { get; set; }

        public StudentsResultsViewModel()
        {
            httpClient = new HttpClient();
            StudentResultList = new ObservableCollection<StudentsResults>();
            GetStudentsResults();
        }

        public async void GetStudentsResults()
        {
            var jsonGetStudentsResults = await httpClient.GetStringAsync(urlGetStudentsResults);

            var studentResults = JsonConvert.DeserializeObject<ObservableCollection<StudentsResults>>(jsonGetStudentsResults);

            foreach(StudentsResults a in studentResults)
            {
                StudentResultList.Add(a);
            }
        }


    }
}
