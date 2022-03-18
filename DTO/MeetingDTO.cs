
namespace SahaBTMeet.DTO
{
    public class MeetingDTO
    {
        public string MeetingName { get; set; }
        public string MeetingSubject { get; set; }
        public string Organizer { get; set; }
        public string StartTime { get; set; }
        public string? EndTime { get; set; } 
        public bool IsCompleted { get; set; }
        public string CreatingTime { get; set; }
        public string JoinLink { get; set; }
        public List<AccountForMeetingDTO> Participants { get; set; }

        public MeetingDTO()
        {

        }

        public MeetingDTO(Meeting meeting)
        {
            this.MeetingName = meeting.Name;
            this.MeetingSubject = meeting.Subject;            
            this.StartTime = meeting.StartTime.ToString("g");
            this.EndTime = meeting.EndTime.ToString("g");           
            this.IsCompleted = meeting.IsCompleted;

            if (meeting.AccountMeeting.Count != 0)
            {
                this.Participants = new List<AccountForMeetingDTO>();
                foreach (AccountMeeting accountMeeting in meeting.AccountMeeting)
                {
                    if (accountMeeting.Account.Id == meeting.OrganizerId)
                    {
                        this.Organizer = accountMeeting.Account.Email;
                    }
                    this.Participants.Add(new AccountForMeetingDTO(accountMeeting.Account));
                    this.JoinLink = accountMeeting.MeetingLink;
                    this.CreatingTime = accountMeeting.CreatingDate.ToString("g");
                }

            }
            else
            {
                meeting.AccountMeeting = null;
                this.Participants = null;
            }
        }
    }
}