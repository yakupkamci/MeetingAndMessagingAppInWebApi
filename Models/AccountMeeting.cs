
namespace SahaBTMeet.Models
{
    public class AccountMeeting
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
        public DateTime CreatingDate { get; set; }
        public string MeetingLink { get; set; }

    }
}