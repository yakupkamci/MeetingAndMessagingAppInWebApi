
namespace SahaBTMeet.Services
{
    public class AddressService : ControllerBase, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<ActionResult<AddressDTO>> CreateAddressOperation(Address address)
        {
            try
            {
                var coming = await _addressRepository.GetAddressByUserId(address.UserId);
                if(coming != null)
                {
                    return BadRequest("Kullanin Db' de Kayitli Adresi Mevcuttur !!!");
                }
                await _addressRepository.CreateAddressOperation(address);
                return address.AddressToDTO();
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=> "+ex.Message);
            }
        }

        public async Task<ActionResult> DeleteAddressOperation(int id)
        {
            try
            {
                Address address = await _addressRepository.GetAddressById(id);
                if(address.Name != null)
                {
                    await _addressRepository.DeleteAddressOperation(address);
                    return Ok("Address Basarili Bir Sekilde Silinmistir !!!");
                }
                return Ok("Db' de Kayitli Address Bulunmamistir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=> "+ex.Message);
            }
        }

        public async Task<ActionResult<AddressDTO>> GetAddressById(int id)
        {
            try
            {
                var coming = (await _addressRepository.GetAddressById(id)).AddressToDTO();
                if(coming.Name != null)
                {
                    return Ok(coming);
                }
                return Ok("Db' de Kayitli Address Bulunmamistir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=> "+ex.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAddressByName(string name)
        {
            try
            {
                var coming = (await _addressRepository.GetAddressByName(name)).AddressToDTO();
                if(coming != null)
                {
                    return Ok(coming);
                }
                return Ok("Db' de Kayitli Address Bulunmamistir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=> "+ex.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAllAddressOperation()
        {
            try
            {
                var comings = (await _addressRepository.GetAllAddressOperation()).AddressToDTO();
                if(comings != null)
                {
                    return Ok(comings);
                }
                return Ok("Db' de Kayitli HicBir Adres Bulunmamistir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=> "+ex.Message);
            }
        }

        public async Task<ActionResult<AddressDTO>> UpdateAddressOperation(int Id, Address address)
        {
            try
            {
                var coming = await _addressRepository.GetAddressById(Id);
                if(coming != null)
                    return (await _addressRepository.UpdateAddressOperation(coming,address)).AddressToDTO();
                else
                    return Ok("Db' de Kayitli HicBir Adres Bulunmamistir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=> "+ex.Message);
            }
        }
    }
}