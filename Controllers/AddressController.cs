

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

        [Authorize("Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAllAddressOperation()
        {
            return await _addressService.GetAllAddressOperation();
        }

        [Authorize("Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> GetAddressById(int id)
        {
            return await _addressService.GetAddressById(id);
        }

        [Authorize("Admin")]
        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAddressByName(string name)
        {
            return await _addressService.GetAddressByName(name);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<AddressDTO>> CreateAddressOperation(Address address)
        {
            return await _addressService.CreateAddressOperation(address);
        }

        [Authorize]
        [HttpPut("id")]
        public async Task<ActionResult<AddressDTO>> UpdateAddressOperation(int id, Address address)
        {
            return await _addressService.UpdateAddressOperation(id, address);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAddressOperation(int id)
        {
            return await _addressService.DeleteAddressOperation(id);
        }
    }
}