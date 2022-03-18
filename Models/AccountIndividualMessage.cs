
namespace SahaBTMeet.Models
{
    public class AccountIndividualMessage
    {
        public int Id { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int IndividualMessageId { get; set; }
        public IndividualMessage IndividualMessage { get; set; }

        public DateTime CreationDate { get; set; }

    }
}