
namespace SahaBTMeet.Services.Interfaces
{
    public interface IAccountService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest Model);
        Task<ActionResult<IEnumerable<AccountDTO>>> GetAllAccountOperation();
        Task<Account> GetAccountById(int Id); // Jwt icin
        Task<ActionResult<AccountDTO>> GetAccountByIdOperation(int Id);
        Task<ActionResult<AccountDTO>> GetAccountByEmailOperation(string Email);
        Task<ActionResult<AccountDTO>> RoleAssignmentToAccountOperation(string Email, List<Role> Role);
        Task<ActionResult<AccountDTO>> RoleRemoveToAccountOperation(string Email, List<Role> Role);
        Task<ActionResult<AccountDTO>> CreateAccountOperation(Account Account);
        Task<ActionResult<AccountDTO>> UpdateAccountOperation(int Id,Account Account);
        Task<ActionResult<AccountDTO>> DeactivateAccountOperation(int Id);
        Task<ActionResult<AccountDTO>> ActivateAccountOperation(int Id);        
        Task<ActionResult<AccountDTO>> ChangeAccountIsBlockedOperation(string Email);
    }
}