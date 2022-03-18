
namespace SahaBTMeet.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        
        public int AccountId { get; set; }
        public Account? Account { get; set; }
        public int DepartmanId { get; set; }
        public Departman? Departman { get; set; }
        public Address? Address { get; set; }


    }
}