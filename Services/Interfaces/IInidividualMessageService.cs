
namespace SahaBTMeet.Services.Interfaces
{
    public interface IIndividualMessageService
    {
        Task<Account> GetAccountById(int Id);
        Task<ActionResult<IndividualMessageDTO>> SendMessageToAccountOperation(int id, IndividualMessage Message);
        Task<ActionResult<IEnumerable<IndividualMessageDTO>>> MyInComingMessagesOperation(int id);
        Task<ActionResult<IEnumerable<IndividualMessageDTO>>> GetAllMessageByAccountOperation(int id, int receiverId);
        Task<ActionResult> DeleteSendMessageToAccountOperation(int id, int MessageId);
        Task<ActionResult> DeleteChatByAccountOperation(int id, int ReceiverId);
    }
}