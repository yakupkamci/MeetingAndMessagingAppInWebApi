
namespace SahaBTMeet.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SahaBTMeetContext _context;
        public AccountRepository(SahaBTMeetContext context)
        {
            _context = context;
        }

        public async Task<Account> ChangeAccountIsBlockedOperation(Account Account)
        {
            Account.IsVisibility = false;
            Account.IsBlocked = true;
            _context.Accounts.Update(Account);
            await _context.SaveChangesAsync();
            return Account;
        }

        public async Task<Account> DeactivateAccountOperation(Account Account)
        {
            Account.IsVisibility = false;
            _context.Accounts.Update(Account);
            await _context.SaveChangesAsync();
            return Account;
        }

        public async Task CreateAccountOperation(Account Account)
        {            
            await _context.Set<Account>().AddAsync(Account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account> GetAccountByEmailOperation(string Email)
        {
            return await _context.Accounts.Include(x=>x.AccountRoles).ThenInclude(x=>x.Role)
                                    .Include(x=>x.User).ThenInclude(x=>x.Departman)
                                    .SingleOrDefaultAsync(x=>x.Email == Email); 
        }

        public Account GetAccountByEmailAndPasswordOperation(string Email, string Password)
        {
            return _context.Set<Account>().SingleOrDefault(q=>q.Email == Email && q.Password == Password);
        }

        public async Task<Account> GetAccountByIdOperation(int Id)
        {
            return await _context.Accounts.Include(x=>x.AccountRoles).ThenInclude(x=>x.Role)
                                    .Include(x=>x.User).ThenInclude(x=>x.Departman)
                                    .SingleOrDefaultAsync(x=>x.Id==Id);                          
        }

        public async Task<List<Account>> GetAllAccountOperation()
        {
            return await _context.Accounts.Include(x=>x.AccountRoles).ThenInclude(x=>x.Role)
                                    .Include(x=>x.User).ThenInclude(x=>x.Departman).ToListAsync(); 
        }

        public async Task<Account> RoleAssignmentToAccountOperation(Account Account, List<Role> Role)
        {
            foreach(Role Assignment in Role){
                Account.AccountRoles.Add(new AccountRole{Account = Account,Role = Assignment});
            }
            await _context.SaveChangesAsync();
            return Account;                
        }

        public async Task<Account> UpdateAccountOperation(Account OldAccount,Account Account)
        {
            OldAccount.Email = Account.Email;
            OldAccount.Password = Account.Password;
            OldAccount.IsVisibility = Account.IsVisibility;
            _context.Accounts.Update(OldAccount);            
            await _context.SaveChangesAsync();
            return OldAccount;
        }

        public async Task<Account> RoleRemoveToAccountOperation(Account Account, List<Role> Role)
        {
            foreach(Role Assignment in Role){
                var InComingAccount = _context.AccountRoles.SingleOrDefault(x=>x.RoleId == Assignment.Id);
                Account.AccountRoles.Remove(InComingAccount);
            }
            await _context.SaveChangesAsync();
            return Account; 
        }

        public async Task<Account> ActivateAccountOperation(Account Account)
        {
            Account.IsVisibility = true;
            _context.Accounts.Update(Account);
            await _context.SaveChangesAsync();
            return Account;
        }
    }
}