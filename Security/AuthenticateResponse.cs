
namespace SahaBTMeet.Security
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsVisibility { get; set; }
        public bool IsBlocked { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Account account, string token)
        {
            Id = account.Id;
            Email = account.Email;
            IsVisibility = account.IsVisibility;
            IsBlocked = account.IsBlocked;
            Token = token;
        }
    }
}