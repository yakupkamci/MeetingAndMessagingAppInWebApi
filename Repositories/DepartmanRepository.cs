
namespace SahaBTMeet.Repositories
{
    public class DepartmanRepository : IDepartmanRepository
    {
        private readonly SahaBTMeetContext _context;
        public DepartmanRepository(SahaBTMeetContext context)
        {
            _context = context;
        }

        public async Task<Departman> CreateDepartmanOperation(Departman departman)
        {
            await _context.Set<Departman>().AddAsync(departman);
            await _context.SaveChangesAsync();
            return departman;
        }

        public async Task<Departman> DeleteDepartmanOperation(Departman departman)
        {
            _context.Departmans.Remove(departman);
            await _context.SaveChangesAsync();
            return departman;
        }

        public async Task<List<Departman>> GetAllDepartmanOperation()
        {
            return await _context.Departmans.ToListAsync();
        }

        public async Task<Departman> GetDepartmanById(int id)
        {
            return await _context.Departmans.SingleOrDefaultAsync(q=>q.Id == id);
        }

        public async Task<Departman> GetDepartmanByName(string name)
        {
            return await _context.Departmans.SingleOrDefaultAsync(q=>q.Name == name);
        }

        public async Task<Departman> UpdateDepartmanOperation(string name,Departman departman)
        {
            Departman oldDepartman = await GetDepartmanByName(name);
            oldDepartman.Name = departman.Name;
            _context.Departmans.Update(oldDepartman);
            await _context.SaveChangesAsync();
            return oldDepartman;
        }
    }
}