
namespace SahaBTMeet.Services.Interfaces
{
    public interface IUserService
    {
        Task<ActionResult<IEnumerable<UserDTO>>> GetAllUserOperation();
        Task<ActionResult<UserDTO>> GetUserById(int id);
        Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByName(string name);
        Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByNameAndSurname(string name, string surname);
        Task<ActionResult<UserDTO>> GetUserByAccountId(int id);
        Task<ActionResult<UserDTO>> GetUserByAccountEmail(string email);
        Task<ActionResult<UserDTO>> CreateUserOperation(User user);
        Task<ActionResult<UserDTO>> UpdateUserOperation(User user);
    }
}