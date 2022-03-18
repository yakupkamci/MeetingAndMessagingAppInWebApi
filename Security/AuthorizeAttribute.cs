
namespace SahaBTMeet.Security
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]    
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public AuthorizeAttribute(params string[] Roles)
        {
            
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            JwtAccountDTO account = (JwtAccountDTO) context.HttpContext.Items["Account"];
            if(account == null)
            {
                context.Result = new JsonResult(new {message="Unauthorized"}) {StatusCode = StatusCodes.Status401Unauthorized};
            }else{
                bool result = account.Roles.Contains("Junior");
            }
        }
    }
}