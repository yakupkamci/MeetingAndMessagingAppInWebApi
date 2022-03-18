
namespace SahaBTMeet.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OpenAddress1 { get; set; }
        public string OpenAddress2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}