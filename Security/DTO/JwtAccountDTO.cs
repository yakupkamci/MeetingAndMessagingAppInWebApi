
namespace SahaBTMeet.Security.DTO
{
    public class JwtAccountDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsVisibility { get; set; }
        public bool IsBlocked { get; set; }
        public List<string> Roles { get; set; }

        public JwtAccountDTO()
        {

        }

        public JwtAccountDTO(Account account)
        {
            if (account != null)
            {
                this.Id = account.Id;
                this.Email = account.Email;
                this.IsVisibility = account.IsVisibility;
                this.IsBlocked = account.IsBlocked;
                if (account.AccountRoles != null)
                {
                    this.Roles = new List<string>();
                    foreach (AccountRole incoming in account.AccountRoles)
                    {
                        this.Roles.Add(incoming.Role.Name);
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