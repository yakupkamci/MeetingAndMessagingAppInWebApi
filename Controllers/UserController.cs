
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUserOperation()
        {
            return await _userService.GetAllUserOperation();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpGet("accountid")]
        public async Task<ActionResult<UserDTO>> GetUserByAccountId(int id)
        {
            return await _userService.GetUserByAccountId(id);
        }

        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByName(string name)
        {
            return await _userService.GetUsersByName(name);
        }

        [HttpGet("namesurname")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByNameAndSurname(string name, string surname)
        {
            return await _userService.GetUsersByNameAndSurname(name,surname);
        }

        [HttpGet("email")]
        public async Task<ActionResult<UserDTO>> GetUserByAccountEmail(string email)
        {
            return await _userService.GetUserByAccountEmail(email);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUserOperation(User user)
        {
            return await _userService.CreateUserOperation(user);
        }

        [HttpPut("id")]
        public async Task<ActionResult<UserDTO>> UpdateUserOperation(int id, User user)
        {
            return await _userService.UpdateUserOperation(id,user);
        }
        
    }
}