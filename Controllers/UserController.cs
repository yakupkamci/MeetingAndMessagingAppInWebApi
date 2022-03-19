
namespace SahaBTMeet.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize("Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUserOperation()
        {
            return await _userService.GetAllUserOperation();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            return await _userService.GetUserById(id);
        }

        [Authorize]
        [HttpGet("accountid")]
        public async Task<ActionResult<UserDTO>> GetUserByAccountId(int id)
        {
            return await _userService.GetUserByAccountId(id);
        }

        [Authorize]
        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByName(string name)
        {
            return await _userService.GetUsersByName(name);
        }

        [Authorize]
        [HttpGet("namesurname")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByNameAndSurname(string name, string surname)
        {
            return await _userService.GetUsersByNameAndSurname(name,surname);
        }

        [Authorize]
        [HttpGet("email")]
        public async Task<ActionResult<UserDTO>> GetUserByAccountEmail(string email)
        {
            return await _userService.GetUserByAccountEmail(email);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUserOperation(User user)
        {
            return await _userService.CreateUserOperation(user);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<UserDTO>> UpdateUserOperation(User user)
        {
            return await _userService.UpdateUserOperation(user);
        }
        
    }
}