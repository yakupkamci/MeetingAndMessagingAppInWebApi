
namespace SahaBTMeet.Services
{
    public class MeetingService : ControllerBase, IMeetingService
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IHttpContextAccessor _httpContext;
        public MeetingService(IHttpContextAccessor httpContext,IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
            _httpContext = httpContext;
        }

        public async Task<ActionResult<MeetingDTO>> AddParticipantToMeetingLaterOperation(int Id, List<Account> Accounts)
        {
            try
            {
                Meeting InComingMeeting = await _meetingRepository.GetMeetingById(Id);
                if (InComingMeeting != null)
                {
                    return Ok((await _meetingRepository.AddParticipantToMeetingLaterOperation(InComingMeeting,Accounts)).MeetingToMeetingDTO());
                }
                return NotFound("Katilimci Eklemek Istediginiz Toplanti Db' de Bulunamadi !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }

        }

        public async Task<ActionResult<MeetingDTO>> CancelMeetingOperation(int Id)
        {
            try
            {
                Meeting InComingMeeting = await _meetingRepository.GetMeetingById(Id);
                if (InComingMeeting != null)
                {
                    return Ok((await _meetingRepository.CancelMeetingOperation(InComingMeeting)).MeetingToMeetingDTO());
                }
                return NotFound("Iptal Etmek Istediginiz Toplanti Db' de Bulunamadi !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }

        }

        public async Task<ActionResult<MeetingDTO>> CreateMeetingOperation(MeetingDIO Meeting)
        {
            try
            {
                JwtAccountDTO httpAccount =(JwtAccountDTO) _httpContext.HttpContext.Items["Account"];
                Account InComingAccount = await _meetingRepository.GetAccountById(httpAccount.Id);
                if (InComingAccount != null)
                {
                    if (Meeting.OrganizerId == null)
                    {
                        Meeting.OrganizerId = httpAccount.Id;
                    }
                    return Ok((await _meetingRepository.CreateMeetingOperation(InComingAccount, Meeting)).MeetingToMeetingDTO());
                }
                return NotFound("Toplanti Olusturmak Istenilen Hesap Db' de Bulunamadi !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<MeetingDTO>> EndTheMeetingOperation(int Id)
        {
            try
            {
                Meeting InComingMeeting = await _meetingRepository.GetMeetingById(Id);
                if(InComingMeeting != null)
                {
                    return Ok((await _meetingRepository.EndTheMeetingOperation(InComingMeeting)).MeetingToMeetingDTO());
                }
                return NotFound("Sonlandirmak Istediginiz Toplanti Db' de Bulunamadi !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<MeetingDTO>>> GetAllMeetingOperation()
        {
            try
            {
                return Ok((await _meetingRepository.GetAllMeetingOperation()).MeetingToMeetingDTO());
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<MeetingDTO>>> GetMeetingByOrganizer()
        {
            try
            {
                JwtAccountDTO httpAccount =(JwtAccountDTO) _httpContext.HttpContext.Items["Account"];
                Account InComingAccount = await _meetingRepository.GetAccountById(httpAccount.Id);
                if (InComingAccount != null)
                {
                    return Ok((await _meetingRepository.GetMeetingByOrganizer(InComingAccount)).MeetingToMeetingDTO());
                }
                return NotFound("Organizator Olan Hesap Db' de Bulunamadi !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<MeetingDTO>>> MyScheduledMeetingByAccount()
        {
            try
            {
                JwtAccountDTO httpAccount =(JwtAccountDTO) _httpContext.HttpContext.Items["Account"];
                Account InComingAccount = await _meetingRepository.GetAccountById(httpAccount.Id);
                if (InComingAccount != null)
                {
                    return Ok((await _meetingRepository.MyScheduledMeetingByAccount(InComingAccount)).MeetingToMeetingDTO());
                }
                return NotFound("Ilgili Hesap Db' de Bulunamadi !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<MeetingDTO>> RemoveParticipantToMeetingOperation(int Id, List<Account> Accounts)
        {
            try
            {
                Meeting InComingMeeting = await _meetingRepository.GetMeetingById(Id);
                if (InComingMeeting != null)
                {
                    return Ok((await _meetingRepository.RemoveParticipantToMeetingOperation(InComingMeeting,Accounts)).MeetingToMeetingDTO());
                }
                return NotFound("Katilimcilari Silmek Istediginiz Toplanti Db' de Bulunamadi !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }
    }
}