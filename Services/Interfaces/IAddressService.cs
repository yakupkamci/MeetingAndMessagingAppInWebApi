
namespace SahaBTMeet.Services.Interfaces
{
    public interface IAddressService
    {
        Task<ActionResult<IEnumerable<AddressDTO>>> GetAllAddressOperation();
        Task<ActionResult<AddressDTO>> GetAddressById(int id);
        Task<ActionResult<IEnumerable<AddressDTO>>> GetAddressByName(string name);
        Task<ActionResult<AddressDTO>> CreateAddressOperation(Address address);
        Task<ActionResult<AddressDTO>> UpdateAddressOperation(int Id, Address address);
        Task<ActionResult> DeleteAddressOperation(int id);
    }
}