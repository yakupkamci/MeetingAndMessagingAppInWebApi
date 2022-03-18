
namespace SahaBTMeet.DIO
{
    public class MeetingDIO
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? OrganizerId { get; set; }
        public bool IsCompleted { get; set; }
        public IEnumerable<Account>? Participants { get; set; }
    
        public MeetingDIO()
        {
            this.Participants = new HashSet<Account>();
        }
    }

  

}

