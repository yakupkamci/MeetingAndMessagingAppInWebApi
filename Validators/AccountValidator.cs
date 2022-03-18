
namespace SahaBTMeet.Validator
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(x=>x.Email).NotNull().WithMessage("Email Boş Geçilemez !!!")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage("Email Formatlarına Uygun Girilmelidir !!!");
            RuleFor(x=>x.Password).NotNull().WithMessage("Password Boş Geçilemez !!!")
                .MinimumLength(6).WithMessage("Password Minimun 6 Haneli Olmalidir !!!")
                .MaximumLength(12).WithMessage("Password Maksimum 12 Haneli Olmalidir !!!");
        }
    }
}