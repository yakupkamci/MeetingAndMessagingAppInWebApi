
namespace SahaBTMeet.Models
{
    public class Departman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User>? User { get; set; }
    }
}