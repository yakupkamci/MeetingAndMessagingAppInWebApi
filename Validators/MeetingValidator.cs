
namespace SahaBTMeet.Validator
{
    public class MeetingValidator : AbstractValidator<MeetingDIO>
    {
        public MeetingValidator()
        {
            RuleFor(x=>x.Name).NotNull().WithMessage("Toplanti Ad Alani Boş Geçilemez !!!");
            RuleFor(x=>x.Subject).NotNull().WithMessage("Toplanti Icerigi Alani Bos Gecilemez !!!");
            RuleFor(x=>x.StartTime).NotNull().WithMessage("Toplanti Baslangic Tarihi ve Saati Alani Bos Gecilemez !!!");
            RuleFor(x=>x.IsCompleted).NotNull().WithMessage("Toplantinin Onay Alani Bos Gecilemez !!!");
        }
    }
}