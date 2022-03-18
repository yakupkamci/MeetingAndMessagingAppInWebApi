
namespace SahaBTMeet.Repositories.Interfaces
{
    public interface IMeetingRepository
    {
        Task<List<Meeting>> MyScheduledMeetingByAccount(Account Account);
        Task<List<Meeting>> GetMeetingByOrganizer(Account Account);
        Task<Meeting> CreateMeetingOperation(Account Account, MeetingDIO meetingDIO);
        Task<Meeting> AddParticipantToMeetingLaterOperation(Meeting Meeting, List<Account> Accounts);
        Task<Meeting> RemoveParticipantToMeetingOperation(Meeting Meeting, List<Account> Accounts);
        Task<Meeting> EndTheMeetingOperation(Meeting Meeting);
        Task<Meeting> CancelMeetingOperation(Meeting Meeting);
        Task<List<Meeting>> GetAllMeetingOperation();
        Task<Account> GetAccountById(int Id);
        Task<Meeting> GetMeetingById(int Id);
    }
}