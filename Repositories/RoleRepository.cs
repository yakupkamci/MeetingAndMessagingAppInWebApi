
namespace SahaBTMeet.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SahaBTMeetContext _context;

        public RoleRepository(SahaBTMeetContext context)
        {
            this._context = context;
        }

        public async Task CreateRoleOperation(Role role)
        {
            await _context.Set<Role>().AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleOperation(Role role)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Role>> GetAllRoleOperation()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _context.Roles.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Role> GetRoleByName(string name)
        {
            return await _context.Roles.SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Role> UpdateRoleOperation(string name, Role role)
        {
            Role InComingRole = await _context.Roles.SingleOrDefaultAsync(x => x.Name == name);
            InComingRole.Name = role.Name;
            _context.Roles.Update(InComingRole);
            await _context.SaveChangesAsync();
            return role;
        }
    }
}