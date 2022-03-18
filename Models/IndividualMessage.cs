
namespace SahaBTMeet.Models
{
    public class IndividualMessage
    {
        public int Id { get; set; }
        public MessageType MessageType { get; set; }
        public string Content { get; set; }
        public int ReceiverAccountId { get; set; }
        public bool IsRead { get; set; }

        public virtual ICollection<AccountIndividualMessage>? AccountIndividualMessages { get; set; }

        public IndividualMessage()
        {
            this.AccountIndividualMessages = new List<AccountIndividualMessage>();
        }

        public IndividualMessage(MessageType messageType, string _content, int receiverAccountId, bool isRead)
        {
            this.MessageType = messageType;
            this.Content = _content;
            this.ReceiverAccountId = receiverAccountId;
            this.IsRead = isRead;
        }
    }
}