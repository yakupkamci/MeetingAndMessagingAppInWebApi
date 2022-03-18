
namespace SahaBTMeet.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public int? OrganizerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsCompleted { get; set; }
        public virtual ICollection<AccountMeeting>? AccountMeeting { get; set; }
        public Meeting()
        {
            this.AccountMeeting = new List<AccountMeeting>();
        }

        public Meeting(MeetingDIO meetingDIO)
        {
            this.Name = meetingDIO.Name;
            this.Subject = meetingDIO.Subject;
            this.OrganizerId = meetingDIO.OrganizerId;
            this.StartTime = meetingDIO.StartTime;
            this.EndTime = meetingDIO.EndTime ?? default(DateTime);
            this.IsCompleted = meetingDIO.IsCompleted;
        }

    }
}