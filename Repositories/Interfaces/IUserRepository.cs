
namespace SahaBTMeet.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUserOperation();
        Task<User> GetUserById(int id);
        Task<List<User>> GetUsersByName(string name);
        Task<List<User>> GetUsersByNameAndSurname(string name, string surname);
        Task<User> GetUserByAccountId(int id);
        Task<User> GetUserByAccountEmail(string email);
        Task<User> CreateUserOperation(User user);
        Task<User> UpdateUserOperation(int id, User user);
    }
}