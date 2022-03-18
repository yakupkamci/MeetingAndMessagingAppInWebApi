
namespace SahaBTMeet.Repositories
{
    public class IndividualMessageRepository : IIndividualMessageRepository
    {
        private readonly SahaBTMeetContext _context;
        public IndividualMessageRepository(SahaBTMeetContext context)
        {
            _context = context;
        }        

        public async Task<Account> GetAccountById(int Id)
        {
            return await _context.Accounts.SingleOrDefaultAsync(q => q.Id == Id);
        }

        public async Task<List<IndividualMessage>> GetAllMessageByAccountOperation(Account account, Account ReceiverAccount)
        {
            var ComingMessages =await (from message in _context.IndividualMessages.Include(x=>x.AccountIndividualMessages).ThenInclude(x=>x.Account)
                                    join ortak in _context.AccountIndividualMessages on message.Id equals ortak.IndividualMessageId
                                    join acc in _context.Accounts on ortak.AccountId equals acc.Id
                                    where (acc.Id == account.Id || acc.Id == ReceiverAccount.Id) 
                                            && (message.ReceiverAccountId == account.Id || message.ReceiverAccountId == ReceiverAccount.Id)
                                    select message).ToListAsync();
            if (ComingMessages != null)
            {
                foreach (IndividualMessage message in ComingMessages)
                {
                    if(message.IsRead == false && message.ReceiverAccountId == account.Id)
                    {
                        message.IsRead = true;
                        _context.IndividualMessages.Update(message);
                    }                    
                }
                await _context.SaveChangesAsync();
            }                                               
            return ComingMessages;
        }

        public async Task<List<IndividualMessage>> MyInComingMessagesOperation(Account account)
        {
            var coming = await _context.IndividualMessages.Include(x => x.AccountIndividualMessages).ThenInclude(x => x.Account)
                               .Where(x => x.ReceiverAccountId == account.Id && x.IsRead == false).ToListAsync();
            if (coming != null)
            {
                foreach (IndividualMessage message in coming)
                {
                    message.IsRead = true;
                    _context.IndividualMessages.Update(message);
                }
                await _context.SaveChangesAsync();
            }
            return coming;
        }

        public async Task<IndividualMessage> SendMessageToAccountOperation(Account account, IndividualMessage Message)
        {
            account.AccountIndividualMessages.Add(
                new AccountIndividualMessage { Account = account, IndividualMessage = Message, CreationDate = DateTime.Now });
            await _context.SaveChangesAsync();
            return Message;
        }
    
        public async Task DeleteChatByAccountOperation(Account account, Account ReceiverAccount)
        {
            var gelen =await (from message in _context.IndividualMessages
                                join accountMessage in _context.AccountIndividualMessages on message.Id equals accountMessage.IndividualMessageId
                                where (message.ReceiverAccountId == account.Id && accountMessage.AccountId == ReceiverAccount.Id) ||
                                    (message.ReceiverAccountId == ReceiverAccount.Id  && accountMessage.AccountId == account.Id)
                                select message).ToListAsync();
            foreach(IndividualMessage individualMessage in gelen)
            {
                _context.IndividualMessages.Remove(individualMessage);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSendMessageToAccountOperation(Account account, IndividualMessage Message)
        {
            Account InComingAccount = await GetAccountById(account.Id);
            var InComingMessage = await _context.AccountIndividualMessages.SingleOrDefaultAsync(q=>q.IndividualMessageId == Message.Id);
            
            InComingAccount.AccountIndividualMessages.Remove(InComingMessage);
            await _context.SaveChangesAsync();
        }

        public async Task<IndividualMessage> GetIndividualMessageById(int id)
        {
            return await _context.IndividualMessages.SingleOrDefaultAsync(x=>x.Id == id);
        }
    }
}