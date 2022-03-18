
namespace SahaBTMeet.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAllAddressOperation();
        Task<Address> GetAddressById(int id);
        Task<List<Address>> GetAddressByName(string name);
        Task<Address> GetAddressByUserId(int id);
        Task CreateAddressOperation(Address address);
        Task<Address> UpdateAddressOperation(Address oldAddress, Address NewAddress);
        Task DeleteAddressOperation(Address address);
    }
}