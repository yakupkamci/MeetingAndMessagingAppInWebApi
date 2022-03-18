

namespace SahaBTMeet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            this._addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAllAddressOperation()
        {
            return await _addressService.GetAllAddressOperation();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> GetAddressById(int id)
        {
            return await _addressService.GetAddressById(id);
        }

        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAddressByName(string name)
        {
            return await _addressService.GetAddressByName(name);
        }

        [HttpPost]
        public async Task<ActionResult<AddressDTO>> CreateAddressOperation(Address address)
        {
            return await _addressService.CreateAddressOperation(address);
        }

        [HttpPut("id")]
        public async Task<ActionResult<AddressDTO>> UpdateAddressOperation(int id, Address address)
        {
            return await _addressService.UpdateAddressOperation(id, address);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAddressOperation(int id)
        {
            return await _addressService.DeleteAddressOperation(id);
        }
    }
}