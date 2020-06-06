namespace testApplication.Models
{
   public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public char Title { get; set; }
        public Account Account { get; set; }
        public Role Role { get; set; }

        public string Summury
        {
            get
            {
                return " Förnamn: " + FirstName + ", Efternamn: " + LastName + ", Email: " + Email + ", Tel.nr: " + Phone;
            }
        }
    }
}
