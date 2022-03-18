
namespace SahaBTMeet.DTO
{
    public class AddressDTO
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string OpenAddress1 { get; set; }
        public string OpenAddress2 { get; set; }

        public AddressDTO()
        {
            
        }

        public AddressDTO(Address Address)
        {
            if(Address != null)
            {
                this.Name = Address.Name;
                this.Country = Address.Country;
                this.City = Address.City;
                this.District = Address.District;
                this.OpenAddress1 = Address.OpenAddress1;
                this.OpenAddress2 = Address.OpenAddress2;
            }
        }
    }
}