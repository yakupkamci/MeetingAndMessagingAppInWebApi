
namespace SahaBTMeet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;
        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingDTO>>> GetAllMeetingOperation()
        {
            return await _meetingService.GetAllMeetingOperation();
        }

        [HttpGet("account")]
        public async Task<ActionResult<IEnumerable<MeetingDTO>>> MyScheduledMeetingByAccount(int id)
        {
            return await _meetingService.MyScheduledMeetingByAccount(id);
        }

        [HttpGet("organizer")]
        public async Task<ActionResult<IEnumerable<MeetingDTO>>> GetMeetingByOrganizer(int id)
        {
            return await _meetingService.GetMeetingByOrganizer(id);
        }

        [HttpPut("addparticipantmeeting")]
        public async Task<ActionResult<MeetingDTO>> AddParticipantToMeetingLaterOperation(int id, List<Account> accounts)
        {
            return await _meetingService.AddParticipantToMeetingLaterOperation(id,accounts);
        }

        [HttpPut("endmeeting")]
        public async Task<ActionResult<MeetingDTO>> EndTheMeetingOperation(int id)
        {
            return await _meetingService.EndTheMeetingOperation(id);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<MeetingDTO>> CreateMeetingOperation(int id, MeetingDIO meeting)
        {
            return await _meetingService.CreateMeetingOperation(id,meeting);
        }

        [HttpDelete("cancelmeeting")]
        public async Task<ActionResult<MeetingDTO>> CancelMeetingOperation(int id)
        {
            return await _meetingService.CancelMeetingOperation(id);
        }

        [HttpDelete("removeparticipantmeeting")]
        public async Task<ActionResult<MeetingDTO>> RemoveParticipantToMeetingOperation(int id, List<Account> accounts)
        {
            return await _meetingService.RemoveParticipantToMeetingOperation(id,accounts);
        }

    }
}