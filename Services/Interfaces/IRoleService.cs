
namespace SahaBTMeet.Services.Interfaces
{
    public interface IRoleService
    {
        Task<ActionResult<IEnumerable<RoleDTO>>> GetAllRoleOperation();
        Task<ActionResult<RoleDTO>> GetRoleById(int id);
        Task<ActionResult<RoleDTO>> GetRoleByName(string name);
        Task<ActionResult<RoleDTO>> CreateRoleOperation(Role role);
        Task<ActionResult<RoleDTO>> UpdateRoleOperation(string name, Role role);
        Task<ActionResult<RoleDTO>> DeleteRoleOperation(int id);
    }
}
