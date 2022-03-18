
namespace SahaBTMeet.Repositories.Interfaces
{
    public interface IIndividualMessageRepository
    {
        Task<Account> GetAccountById(int Id); 
        Task<IndividualMessage> GetIndividualMessageById(int id);       
        Task<List<IndividualMessage>> MyInComingMessagesOperation(Account account);
        Task<List<IndividualMessage>> GetAllMessageByAccountOperation(Account account, Account ReceiverAccount);
        Task<IndividualMessage> SendMessageToAccountOperation(Account account, IndividualMessage Message);
        Task DeleteSendMessageToAccountOperation(Account account, IndividualMessage Message);
        Task DeleteChatByAccountOperation(Account account, Account ReceiverAccount);
    }
}