
namespace SahaBTMeet.Security
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]    
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var account = context.HttpContext.Items["Account"];
            if(account == null)
            {
                context.Result = new JsonResult(new {message="Unauthorized"}) {StatusCode = StatusCodes.Status401Unauthorized};
            }
        }
    }
}