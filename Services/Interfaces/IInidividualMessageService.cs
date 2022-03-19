
namespace SahaBTMeet.Services.Interfaces
{
    public interface IIndividualMessageService
    {
        Task<Account> GetAccountById(int Id);
        Task<ActionResult<IndividualMessageDTO>> SendMessageToAccountOperation(IndividualMessage Message);
        Task<ActionResult<IEnumerable<IndividualMessageDTO>>> MyInComingMessagesOperation();
        Task<ActionResult<IEnumerable<IndividualMessageDTO>>> GetAllMessageByAccountOperation(int receiverId);
        Task<ActionResult> DeleteSendMessageToAccountOperation(int MessageId);
        Task<ActionResult> DeleteChatByAccountOperation(int ReceiverId);
    }
}