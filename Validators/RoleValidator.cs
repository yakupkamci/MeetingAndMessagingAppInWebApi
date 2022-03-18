
namespace SahaBTMeet.Validator
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(x=>x.Name).NotNull().WithMessage("Rol Ad Alani Boş Geçilemez !!!");
        }
    }
}