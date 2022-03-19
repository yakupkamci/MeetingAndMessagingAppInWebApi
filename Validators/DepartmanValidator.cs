
namespace SahaBTMeet.Validator
{
    public class DepartmanValidator : AbstractValidator<Departman>
    {
        public DepartmanValidator()
        {
            RuleFor(x=>x.Name).NotNull().WithMessage("Departman Ad Alani Boş Geçilemez !!!");
        }
    }
}