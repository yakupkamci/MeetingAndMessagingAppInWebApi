
namespace SahaBTMeet.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRoleOperation();
        Task<Role> GetRoleById(int id);
        Task<Role> GetRoleByName(string name);
        Task CreateRoleOperation(Role role);
        Task<Role> UpdateRoleOperation(string name,Role role);
        Task DeleteRoleOperation(Role role);

    }
}