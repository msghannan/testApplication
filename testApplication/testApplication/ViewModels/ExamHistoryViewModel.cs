using testApplication.Models;

namespace testApplication.ViewModels
{
    public class ExamHistoryViewModel
    {
        public int Id { get; set; }
        public string Grade { get; set; }
        public Person Person { get; set; }
        public Test Test { get; set; }
        public string Summury
        {
            get
            {
               return "Elevens ID: " + Id + ", Förnamn: " + Person.FirstName + ", Efternamn: " + Person.LastName + ", Prov: " + Test.TestName + ", Betyg: " + Grade; 
            }
        }
    }
}
