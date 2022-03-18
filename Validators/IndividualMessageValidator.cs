
namespace SahaBTMeet.Validator
{
    public class IndividualMessageValidator : AbstractValidator<IndividualMessage>
    {
        public IndividualMessageValidator()
        {
            RuleFor(x=>x.MessageType).NotNull().WithMessage("Mesaj Tipi Alani Boş Geçilemez !!!");
            RuleFor(x=>x.Content).NotNull().WithMessage("Mesaj Icerigi Alani Bos Gecilemez !!!");
            RuleFor(x=>x.ReceiverAccountId).NotNull().WithMessage("Mesaj Alici Hesap Alani Bos Gecilemez !!!");
        }
    }
}