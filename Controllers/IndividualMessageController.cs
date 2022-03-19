
namespace SahaBTMeet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class IndividualMessageController : ControllerBase
    {
        private readonly IIndividualMessageService _individualMessageRepository;
        public IndividualMessageController(IIndividualMessageService individualMessageRepository)
        {
            _individualMessageRepository = individualMessageRepository;
        }

        [HttpGet("mycoming")]
        public async Task<ActionResult<IEnumerable<IndividualMessageDTO>>> MyInComingIndividualMessageOperation()
        {
            return await _individualMessageRepository.MyInComingMessagesOperation();
        }

        [HttpGet("receiverid")]
        public async Task<ActionResult<IEnumerable<IndividualMessageDTO>>> GetAllMessageByAccountOperation(int receiverid)
        {
            return await _individualMessageRepository.GetAllMessageByAccountOperation(receiverid);
        }

        [HttpPost]
        public async Task<ActionResult<IndividualMessageDTO>> SendIndividualMessageToAccount(IndividualMessage message)
        {
            return await _individualMessageRepository.SendMessageToAccountOperation(message);
        }

        [HttpDelete("deletechat")]
        public async Task<ActionResult> DeleteChatByAccountOperation(int receiverid)
        {
            return await _individualMessageRepository.DeleteChatByAccountOperation(receiverid);
        }

        [HttpDelete("deletemessage")]
        public async Task<ActionResult> DeleteSendMessageToAccountOperation(int messageid)
        {
            return await _individualMessageRepository.DeleteSendMessageToAccountOperation(messageid);
        }

        
    }
}