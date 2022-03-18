
namespace SahaBTMeet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndividualMessageController : ControllerBase
    {
        private readonly IIndividualMessageService _individualMessageRepository;
        public IndividualMessageController(IIndividualMessageService individualMessageRepository)
        {
            _individualMessageRepository = individualMessageRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<IndividualMessageDTO>>> MyInComingIndividualMessageOperation(int id)
        {
            return await _individualMessageRepository.MyInComingMessagesOperation(id);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<IndividualMessageDTO>>> GetAllMessageByAccountOperation(int id, int receiverid)
        {
            return await _individualMessageRepository.GetAllMessageByAccountOperation(id,receiverid);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<IndividualMessageDTO>> SendIndividualMessageToAccount(int id, IndividualMessage message)
        {
            return await _individualMessageRepository.SendMessageToAccountOperation(id,message);
        }

        [HttpDelete("deletechat")]
        public async Task<ActionResult> DeleteChatByAccountOperation(int id, int receiverid)
        {
            return await _individualMessageRepository.DeleteChatByAccountOperation(id,receiverid);
        }

        [HttpDelete("deletemessage")]
        public async Task<ActionResult> DeleteSendMessageToAccountOperation(int id, int messageid)
        {
            return await _individualMessageRepository.DeleteSendMessageToAccountOperation(id,messageid);
        }

        
    }
}