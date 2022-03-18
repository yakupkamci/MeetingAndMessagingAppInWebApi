
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


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAllAccountOperation()
        {
            return await _accountService.GetAllAccountOperation();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetAccountByIdOperation(int id)
        {
            return await _accountService.GetAccountByIdOperation(id);
        }

        [HttpGet("email")]
        public async Task<ActionResult<AccountDTO>> GetAccountByEmailOperation(string email)
        {
            return await _accountService.GetAccountByEmailOperation(email);
        }
      
        [HttpPost]
        public async Task<ActionResult<AccountDTO>> CreateAccountOperation(Account account)
        {
            return await _accountService.CreateAccountOperation(account);
        }
        
        [HttpPost("roleassignment")]
        public async Task<ActionResult<AccountDTO>> RoleAssignmentToAccountOperation(string email, List<Role> role)
        {
            return await _accountService.RoleAssignmentToAccountOperation(email,role);
        } 

        [HttpPut("{id}")]
        public async Task<ActionResult<AccountDTO>> UpdateAccountOperation(int id, Account account)
        {
            return await _accountService.UpdateAccountOperation(id,account);
        }

        [HttpPut("deactivate")]
        public async Task<ActionResult<AccountDTO>> DeactivateAccountOperation(int id)
        {
            return await _accountService.DeactivateAccountOperation(id);
        }

        [HttpPut("activate")]
        public async Task<ActionResult<AccountDTO>> ActivateAccountOperation(int id)
        {
            return await _accountService.ActivateAccountOperation(id);
        }

        [HttpDelete("roleremove")]
        public async Task<ActionResult<AccountDTO>> RoleRemoveToAccountOperation(string email, List<Role> role)
        {
            return await _accountService.RoleRemoveToAccountOperation(email,role);
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult<AccountDTO>> BlockedAccountOperation(string email)
        {
            return await _accountService.ChangeAccountIsBlockedOperation(email);
        }



        [HttpPost("authenticate")]
        public IActionResult LoginAccount(AuthenticateRequest model)
        {
            var response = _accountService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

    }

}