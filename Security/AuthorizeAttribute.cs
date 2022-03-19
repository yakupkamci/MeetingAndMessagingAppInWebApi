
namespace SahaBTMeet.Security
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]    
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<string> _roles;
        public AuthorizeAttribute(params string[] Roles)
        {
            _roles = Roles ?? new string[]{};
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            JwtAccountDTO account = (JwtAccountDTO) context.HttpContext.Items["Account"];
            if(account == null)
            {
                context.Result = new JsonResult(new {message="Unauthorized"}) {StatusCode = StatusCodes.Status401Unauthorized};
            }
            else if(_roles.Count() != 0)
            {
                bool ApprovalFlag = false;
                foreach(string searchRole in _roles)
                {
                    if(account.Roles.Contains(searchRole)){ApprovalFlag = true; break;}
                }
                if(!ApprovalFlag)
                {
                    context.Result = new JsonResult(new {message="Unauthorized"}) {StatusCode = StatusCodes.Status401Unauthorized};
                }
            }
        }
    }
}