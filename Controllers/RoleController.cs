
namespace SahaBTMeet.Controllers
{
    [Authorize("Admin")]
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetAllRoleOperation()
        {
            return await _roleService.GetAllRoleOperation();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRoleById(int id)
        {
            return await _roleService.GetRoleById(id);
        }

        [HttpGet("name")]
        public async Task<ActionResult<RoleDTO>> GetRoleByName(string name)
        {
            return await _roleService.GetRoleByName(name);
        }

        [HttpPost]
        public async Task<ActionResult<RoleDTO>> CreateRoleOperation(Role role)
        {
            return await _roleService.CreateRoleOperation(role);
        }

        [HttpPut("{name}")]
        public async Task<ActionResult<RoleDTO>> UpdateRoleOperation(string name, Role role)
        {
            return await _roleService.UpdateRoleOperation(name, role);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RoleDTO>> DeleteRoleOperation(int id)
        {
            return await _roleService.DeleteRoleOperation(id);
        }
    }
}