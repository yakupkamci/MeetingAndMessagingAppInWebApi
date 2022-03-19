
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

        [Authorize("Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingDTO>>> GetAllMeetingOperation()
        {
            return await _meetingService.GetAllMeetingOperation();
        }

        [Authorize]
        [HttpGet("account")]
        public async Task<ActionResult<IEnumerable<MeetingDTO>>> MyScheduledMeetingByAccount()
        {
            return await _meetingService.MyScheduledMeetingByAccount();
        }

        [Authorize]
        [HttpGet("organizer")]
        public async Task<ActionResult<IEnumerable<MeetingDTO>>> GetMeetingByOrganizer()
        {
            return await _meetingService.GetMeetingByOrganizer();
        }

        [Authorize("Admin","Senior","Team Lead")]
        [HttpPut("addparticipantmeeting")]
        public async Task<ActionResult<MeetingDTO>> AddParticipantToMeetingLaterOperation(int id, List<Account> accounts)
        {
            return await _meetingService.AddParticipantToMeetingLaterOperation(id,accounts);
        }

        [Authorize("Admin","Senior","Team Lead")]
        [HttpPut("endmeeting")]
        public async Task<ActionResult<MeetingDTO>> EndTheMeetingOperation(int id)
        {
            return await _meetingService.EndTheMeetingOperation(id);
        }

        [Authorize("Admin","Senior","Team Lead")]
        [HttpPost]
        public async Task<ActionResult<MeetingDTO>> CreateMeetingOperation(MeetingDIO meeting)
        {
            return await _meetingService.CreateMeetingOperation(meeting);
        }

        [Authorize("Admin","Senior","Team Lead")]
        [HttpDelete("cancelmeeting")]
        public async Task<ActionResult<MeetingDTO>> CancelMeetingOperation(int id)
        {
            return await _meetingService.CancelMeetingOperation(id);
        }

        [Authorize("Admin","Senior","Team Lead")]
        [HttpDelete("removeparticipantmeeting")]
        public async Task<ActionResult<MeetingDTO>> RemoveParticipantToMeetingOperation(int id, List<Account> accounts)
        {
            return await _meetingService.RemoveParticipantToMeetingOperation(id,accounts);
        }

    }
}