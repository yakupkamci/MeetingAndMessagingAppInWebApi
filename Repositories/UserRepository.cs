
namespace SahaBTMeet.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SahaBTMeetContext _context;
        public UserRepository(SahaBTMeetContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserOperation(User user)
        {
            await _context.Set<User>().AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUserOperation()
        {
            return await _context.Users.Include(x=>x.Account).Include(x=>x.Departman).ToListAsync();
        }
        
        public async Task<User> GetUserByAccountEmail(string email)
        {
            return await _context.Users.Include(x=>x.Account).Include(x=>x.Departman)
                        .SingleOrDefaultAsync(q=>q.Account.Email==email);
        }

        public async Task<User> GetUserByAccountId(int id)
        {
            return await _context.Users.Include(x=>x.Account).Include(x=>x.Departman)
                        .SingleOrDefaultAsync(q=>q.AccountId == id);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.Include(x=>x.Account).Include(x=>x.Departman)
                        .SingleOrDefaultAsync(q=>q.Id == id);
        }

        public async Task<List<User>> GetUsersByName(string name)
        {
            return await _context.Users.Include(x=>x.Account).Include(x=>x.Departman)
                        .Where(q=>q.Name == name).ToListAsync();
        }

        public async Task<List<User>> GetUsersByNameAndSurname(string name, string surname)
        {
            return await _context.Users.Include(x=>x.Account).Include(x=>x.Departman)
                        .Where(q=>q.Name == name && q.Surname == surname).ToListAsync();
        }

        public async Task<User> UpdateUserOperation(int id, User user)
        {
            User InComingUser = await _context.Users.SingleOrDefaultAsync(q=>q.Id == id);
            InComingUser.Name = user.Name;
            InComingUser.Surname = user.Surname;
            InComingUser.Gender = user.Gender;

            _context.Users.Update(InComingUser);
            await _context.SaveChangesAsync();
            return InComingUser;
        }
    }
}