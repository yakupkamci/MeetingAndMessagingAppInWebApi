
namespace SahaBTMeet.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string AccountEmail { get; set; }
        public bool IsVisibility { get; set; }
        public string DepartmanName { get; set; }

        public UserDTO(User user)
        {
            if(user != null)
            {         
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.Gender = user.Gender;
            if (user.Account != null)
            {
                this.AccountEmail = user.Account.Email;
                this.IsVisibility = user.Account.IsVisibility;
                this.DepartmanName = user.Departman.Name;
            }
            }
        }
    }
}