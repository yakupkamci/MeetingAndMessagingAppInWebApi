
namespace SahaBTMeet.DTO
{
    public class AccountForMeetingDTO
    {
        public string Email { get; set; }
        public bool IsVisibility { get; set; } 
        public AccountForMeetingDTO()
        {            
        }
        public AccountForMeetingDTO(Account account)
        {
            this.Email = account.Email;
            this.IsVisibility = account.IsVisibility;
        }
    }
}