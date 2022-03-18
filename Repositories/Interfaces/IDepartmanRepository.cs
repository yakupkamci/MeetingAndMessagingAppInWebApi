
namespace SahaBTMeet.Repositories.Interfaces
{
    public interface IDepartmanRepository
    {
        Task<List<Departman>> GetAllDepartmanOperation();
        Task<Departman> GetDepartmanById(int id);
        Task<Departman> GetDepartmanByName(string name);
        Task<Departman> CreateDepartmanOperation(Departman departman);
        Task<Departman> UpdateDepartmanOperation(string name,Departman departman);
        Task<Departman> DeleteDepartmanOperation(Departman departman);
    }
}