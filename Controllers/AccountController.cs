
namespace SahaBTMeet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [Authorize("Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAllAccountOperation()
        {
            return await _accountService.GetAllAccountOperation();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetAccountByIdOperation(int id)
        {
            return await _accountService.GetAccountByIdOperation(id);
        }

        [Authorize]
        [HttpGet("email")]
        public async Task<ActionResult<AccountDTO>> GetAccountByEmailOperation(string email)
        {
            return await _accountService.GetAccountByEmailOperation(email);
        }
      
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<AccountDTO>> CreateAccountOperation(Account account)
        {
            return await _accountService.CreateAccountOperation(account);
        }
        
        [Authorize("Admin")]
        [HttpPost("roleassignment")]
        public async Task<ActionResult<AccountDTO>> RoleAssignmentToAccountOperation(string email, List<Role> role)
        {
            return await _accountService.RoleAssignmentToAccountOperation(email,role);
        } 

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<AccountDTO>> UpdateAccountOperation(Account account)
        {
            return await _accountService.UpdateAccountOperation(account);
        }

        [Authorize("Admin")]
        [HttpPut("deactivate")]
        public async Task<ActionResult<AccountDTO>> DeactivateAccountOperation(int id)
        {
            return await _accountService.DeactivateAccountOperation(id);
        }

        [Authorize("Admin")]
        [HttpPut("activate")]
        public async Task<ActionResult<AccountDTO>> ActivateAccountOperation(int id)
        {
            return await _accountService.ActivateAccountOperation(id);
        }

        [Authorize("Admin")]
        [HttpDelete("roleremove")]
        public async Task<ActionResult<AccountDTO>> RoleRemoveToAccountOperation(string email, List<Role> role)
        {
            return await _accountService.RoleRemoveToAccountOperation(email,role);
        }

        [Authorize("Admin")]
        [HttpDelete("{email}")]
        public async Task<ActionResult<AccountDTO>> BlockedAccountOperation(string email)
        {
            return await _accountService.ChangeAccountIsBlockedOperation(email);
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult LoginAccount(AuthenticateRequest model)
        {
            var response = _accountService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

    }

}