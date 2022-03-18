
namespace SahaBTMeet.DTO
{
    public class IndividualMessageDTO
    {
        public MessageType MessageType { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public string MessageTime { get; set; }
        public bool IsRead { get; set; }

        public IndividualMessageDTO()
        {
            
        }

        public IndividualMessageDTO(IndividualMessage message)
        {
            this.MessageType = message.MessageType;
            this.Content = message.Content;
            this.IsRead = message.IsRead;
            if(message.AccountIndividualMessages != null)
            {
                var accountIndividualMessage = message.AccountIndividualMessages.ElementAt(0);
                this.Sender = accountIndividualMessage.Account.Email;
                this.MessageTime = accountIndividualMessage.CreationDate.ToString("g");
            }else{
                this.Sender = null;
                this.MessageTime = null;
            }         
            
        }
    }
}