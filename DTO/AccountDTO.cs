
namespace SahaBTMeet.DTO
{
    public class AccountDTO
    {
        public string Email { get; set; }
        public bool IsVisibility { get; set; }
        public bool IsBlocked { get; set; }

        public string userName { get; set; }
        public string userSurname { get; set; }
        public Gender userGender { get; set; }

        public List<RoleDTO> Roles { get; set; }
        public string userDepartmanName { get; set; }

        public AccountDTO()
        {

        }

        public AccountDTO(Account account)
        {
            if (account != null)
            {
                this.Email = account.Email;
                this.IsVisibility = account.IsVisibility;
                this.IsBlocked = account.IsBlocked;
                if (account.User != null)
                {
                    this.userName = account.User.Name;
                    this.userSurname = account.User.Surname;
                    this.userGender = account.User.Gender;
                    this.userDepartmanName = account.User.Departman.Name;
                }
                else
                {
                    account.User = null;
                }
                if (account.AccountRoles != null)
                {
                    this.Roles = new List<RoleDTO>();
                    foreach (AccountRole incoming in account.AccountRoles)
                    {
                        this.Roles.Add(new RoleDTO(incoming.Role));
                    }
                }
                else
                {
                    account.AccountRoles = null;
                }
            }
        }

    }

}