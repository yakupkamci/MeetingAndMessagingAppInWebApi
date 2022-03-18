
namespace SahaBTMeet.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly SahaBTMeetContext _context;

        public AddressRepository(SahaBTMeetContext context)
        {
            _context = context;
        }

        public async Task CreateAddressOperation(Address address)
        {
           await _context.Set<Address>().AddAsync(address);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAddressOperation(Address address)
        {
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }

        public async Task<Address> GetAddressById(int id)
        {
            return await _context.Addresses.SingleOrDefaultAsync(q=>q.Id == id);
        }

        public async Task<List<Address>> GetAddressByName(string name)
        {
            return await _context.Addresses.Where(q=>q.Name == name).ToListAsync();
        }

        public async Task<Address> GetAddressByUserId(int id)
        {
            return await _context.Addresses.SingleOrDefaultAsync(q=>q.UserId == id);
        }

        public async Task<List<Address>> GetAllAddressOperation()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> UpdateAddressOperation(Address OldAddress,Address NewAddress)
        {
            OldAddress.Name = NewAddress.Name;
            OldAddress.Country = NewAddress.Country;
            OldAddress.City = NewAddress.City;
            OldAddress.District = NewAddress.District;
            OldAddress.OpenAddress1 = NewAddress.OpenAddress1;
            OldAddress.OpenAddress2 = NewAddress.OpenAddress2;

            _context.Addresses.Update(OldAddress);
            await _context.SaveChangesAsync();
            return OldAddress;            
        }
    }
}