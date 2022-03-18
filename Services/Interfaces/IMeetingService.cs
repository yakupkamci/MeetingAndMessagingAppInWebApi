
namespace SahaBTMeet.Services.Interfaces
{
    public interface IMeetingService
    {
        Task<ActionResult<IEnumerable<MeetingDTO>>> MyScheduledMeetingByAccount(int Id);
        Task<ActionResult<IEnumerable<MeetingDTO>>> GetMeetingByOrganizer(int Id);
        Task<ActionResult<MeetingDTO>> CreateMeetingOperation(int Id, MeetingDIO Meeting);
        Task<ActionResult<MeetingDTO>> AddParticipantToMeetingLaterOperation(int Id, List<Account> Accounts);
        Task<ActionResult<MeetingDTO>> RemoveParticipantToMeetingOperation(int Id, List<Account> Accounts);
        Task<ActionResult<MeetingDTO>> EndTheMeetingOperation(int Id);
        Task<ActionResult<MeetingDTO>> CancelMeetingOperation(int Id);
        Task<ActionResult<IEnumerable<MeetingDTO>>> GetAllMeetingOperation();
    }
}