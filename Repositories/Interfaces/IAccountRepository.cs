
namespace SahaBTMeet.Repositories.Interfaces
{
    public interface IAccountRepository
    {        
        Account GetAccountByEmailAndPasswordOperation(string Email, string Password);
        Task<List<Account>> GetAllAccountOperation();
        Task<Account> GetAccountByIdOperation(int Id);
        Task<Account> GetAccountByEmailOperation(string Email);
        Task<Account> RoleAssignmentToAccountOperation(Account Account, List<Role> Role);
        Task<Account> RoleRemoveToAccountOperation(Account Account, List<Role> Role);
        Task CreateAccountOperation(Account Account);
        Task<Account> UpdateAccountOperation(Account OldAccount,Account NewAccount);
        Task<Account> DeactivateAccountOperation(Account Account);
        Task<Account> ActivateAccountOperation(Account Account);
        Task<Account> ChangeAccountIsBlockedOperation(Account Account);

    }
}