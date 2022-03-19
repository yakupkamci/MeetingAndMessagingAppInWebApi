
namespace SahaBTMeet.Services
{
    public class IndividualMessageService : ControllerBase, IIndividualMessageService
    {
        private readonly IIndividualMessageRepository _individualMessageRepository;
        private readonly IHttpContextAccessor _httpContext;
        public IndividualMessageService(IHttpContextAccessor httpContext,IIndividualMessageRepository individualMessageRepository)
        {
            _individualMessageRepository = individualMessageRepository;
            _httpContext = httpContext;
        }

        public async Task<ActionResult> DeleteChatByAccountOperation(int receiverId)
        {
            try
            {
                JwtAccountDTO httpAccount =(JwtAccountDTO) _httpContext.HttpContext.Items["Account"];
                Account InComingAccount = await GetAccountById(httpAccount.Id);
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

        public async Task<ActionResult> DeleteSendMessageToAccountOperation(int MessageId)
        {
            try
            {
                JwtAccountDTO httpAccount =(JwtAccountDTO) _httpContext.HttpContext.Items["Account"];
                Account InComingAccount = await GetAccountById(httpAccount.Id);
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

        public async Task<ActionResult<IEnumerable<IndividualMessageDTO>>> GetAllMessageByAccountOperation(int receiverId)
        {
            try
            {
                JwtAccountDTO httpAccount =(JwtAccountDTO) _httpContext.HttpContext.Items["Account"];
                Account InComingAccount = await GetAccountById(httpAccount.Id);
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

        public async Task<ActionResult<IEnumerable<IndividualMessageDTO>>> MyInComingMessagesOperation()
        {
            try
            {
                JwtAccountDTO httpAccount =(JwtAccountDTO) _httpContext.HttpContext.Items["Account"];
                Account InComingAccount = await GetAccountById(httpAccount.Id);
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

        public async Task<ActionResult<IndividualMessageDTO>> SendMessageToAccountOperation(IndividualMessage Message)
        {
            try
            {
                JwtAccountDTO httpAccount =(JwtAccountDTO) _httpContext.HttpContext.Items["Account"];
                Account InComingAccount = await GetAccountById(httpAccount.Id);
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