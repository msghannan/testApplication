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
        public ObservableCollection<StudentsResults> StudentResultList { get; set; }

        public StudentsResultsViewModel()
        {
            StudentResultList = new ObservableCollection<StudentsResults>();
        }
    }
}
