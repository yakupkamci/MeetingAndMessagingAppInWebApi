using System;

namespace SahaBTMeet.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsVisibility { get; set; }
        public bool IsBlocked { get; set; }
        public User? User { get; set; }
        public virtual ICollection<AccountRole>? AccountRoles { get; set; }
        public virtual ICollection<AccountIndividualMessage>? AccountIndividualMessages { get; set; }
        public virtual ICollection<AccountMeeting>? AccountMeeting { get; set; }

        public Account()
        {
            this.AccountRoles = new HashSet<AccountRole>();
            this.AccountIndividualMessages = new List<AccountIndividualMessage>();
            this.AccountMeeting = new HashSet<AccountMeeting>();
        }

       

    }
}