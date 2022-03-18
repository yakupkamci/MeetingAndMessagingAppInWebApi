
namespace SahaBTMeet.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x=>x.Name).NotNull().WithMessage("Ad Alani Boş Geçilemez !!!");
            RuleFor(x=>x.Surname).NotNull().WithMessage("Soyad Alani Boş Geçilemez !!!");
            RuleFor(x=>x.Gender).NotNull().WithMessage("Cinsiyet Alani Boş Geçilemez !!!");
            RuleFor(x=>x.AccountId).NotNull().WithMessage("Kullanicinin Bagli Oldugu Hesap Alani Boş Geçilemez !!!");
            RuleFor(x=>x.DepartmanId).NotNull().WithMessage("Kullanicinin Bagli Oldugu Departman Alani Boş Geçilemez !!!");
        }
    }
}