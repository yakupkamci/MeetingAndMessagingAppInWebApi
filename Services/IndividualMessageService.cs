
namespace SahaBTMeet.Services
{
    public class IndividualMessageService : ControllerBase, IIndividualMessageService
    {
        private readonly IIndividualMessageRepository _individualMessageRepository;

        public IndividualMessageService(IIndividualMessageRepository individualMessageRepository)
        {
            _individualMessageRepository = individualMessageRepository;
        }

        public async Task<ActionResult> DeleteChatByAccountOperation(int id, int receiverId)
        {
            try
            {
                Account InComingAccount = await GetAccountById(id);
                Account InComingReceiver = await GetAccountById(receiverId);
                if(InComingAccount != null)
                {
                    if(InComingReceiver != null)
                    {
                        await _individualMessageRepository.DeleteChatByAccountOperation(InComingAccount,InComingReceiver);
                        return Ok("Chat Basari ile Silinmistir !!!");
                    }
                    return BadRequest("Alici Hesap Db' de Bulunamamistir !!!");
                }
                return BadRequest("Hesap Db' de Bulunamamistir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult> DeleteSendMessageToAccountOperation(int id, int MessageId)
        {
            try
            {
                Account InComingAccount = await GetAccountById(id);
                IndividualMessage InComingMessage = await _individualMessageRepository.GetIndividualMessageById(MessageId);
                if(InComingAccount != null)
                {
                    if(InComingMessage != null)
                    {
                        await _individualMessageRepository.DeleteSendMessageToAccountOperation(InComingAccount,InComingMessage);
                        return Ok("Mesaj Basari ile Silinmistir !!!");
                    }
                    return BadRequest("Kayitli Hesap Bulunamamistir !!!");
                }
                return BadRequest("Hesap Db' de Bulunamamistir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<Account> GetAccountById(int Id)
        {
            try
            {
                return await _individualMessageRepository.GetAccountById(Id);
            }catch(Exception ex){
                throw new NotImplementedException();
            }            
        }

        public async Task<ActionResult<IEnumerable<IndividualMessageDTO>>> GetAllMessageByAccountOperation(int id, int receiverId)
        {
            try
            {
                Account InComingAccount = await GetAccountById(id);
                Account InComingReceiver = await GetAccountById(receiverId);
                if(InComingAccount != null)
                {
                    if(InComingReceiver != null)
                    {
                        return Ok((await _individualMessageRepository.GetAllMessageByAccountOperation(InComingAccount,InComingReceiver)).IndividualMessageToDTO());
                    }
                    return BadRequest("Alici Hesap Db' de Bulunamamistir !!!");
                }
                return BadRequest("Hesap Db' de Bulunamamistir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<IndividualMessageDTO>>> MyInComingMessagesOperation(int id)
        {
            try
            {
                Account InComingAccount = await GetAccountById(id);
                if(InComingAccount != null)
                {
                    return Ok((await _individualMessageRepository.MyInComingMessagesOperation(InComingAccount)).IndividualMessageToDTO());
                }
                return BadRequest("Hesap Db' de Bulunamamistir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<IndividualMessageDTO>> SendMessageToAccountOperation(int id, IndividualMessage Message)
        {
            try
            {
                Account InComingAccount = await GetAccountById(id);
                if(InComingAccount != null)
                {
                    return Ok((await _individualMessageRepository.SendMessageToAccountOperation(InComingAccount,Message)).IndividualMessageToDTO());
                }
                return BadRequest("Hesap Db' de Bulunamamistir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

    }
}