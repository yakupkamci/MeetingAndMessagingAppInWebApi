
namespace SahaBTMeet.Services.Interfaces
{
    public interface IDepartmanService
    {
        Task<ActionResult<IEnumerable<DepartmanDTO>>> GetAllDepartmanOperation();
        Task<ActionResult<DepartmanDTO>> GetDepartmanById(int id);
        Task<ActionResult<DepartmanDTO>> GetDepartmanByName(string name);
        Task<ActionResult<DepartmanDTO>> CreateDepartmanOperation(Departman departman);
        Task<ActionResult<DepartmanDTO>> UpdateDepartmanOperation(string name, Departman departman);
        Task<ActionResult<DepartmanDTO>> DeleteDepartmanOperation(int id);
    }
}