
namespace SahaBTMeet.Validator
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x=>x.Name).NotNull().WithMessage("Adresin Ad Alani Boş Geçilemez !!!");
            RuleFor(x=>x.Country).NotNull().WithMessage("Ulke Alani Boş Geçilemez !!!");
            RuleFor(x=>x.City).NotNull().WithMessage("Sehir Alani Boş Geçilemez !!!");
            RuleFor(x=>x.District).NotNull().WithMessage("Ilce Alani Boş Geçilemez !!!");
            RuleFor(x=>x.OpenAddress1).NotNull().WithMessage("1. Acik Adres Alani Boş Geçilemez !!!");
        }
    }
}