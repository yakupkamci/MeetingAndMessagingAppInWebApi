
namespace SahaBTMeet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmanController : ControllerBase
    {
        private readonly IDepartmanService _departmanService;
        public DepartmanController(IDepartmanService departmanService)
        {
            _departmanService = departmanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmanDTO>>> GetAllDepartmanOperation()
        {
            return await _departmanService.GetAllDepartmanOperation();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmanDTO>> GetDepartmanById(int id)
        {
            return await _departmanService.GetDepartmanById(id);
        }

        [HttpGet("name")]
        public async Task<ActionResult<DepartmanDTO>> GetDepartmanByName(string name)
        {
            return await _departmanService.GetDepartmanByName(name);
        }

        [HttpPost]
        public async Task<ActionResult<DepartmanDTO>> CreateDepartmanOperation(Departman departman)
        {
            return await _departmanService.CreateDepartmanOperation(departman);
        }

        [HttpPut("name")]
        public async Task<ActionResult<DepartmanDTO>> UpdateDepartmanOperation(string name, Departman departman)
        {
            return await _departmanService.UpdateDepartmanOperation(name,departman);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DepartmanDTO>> DeleteDepartmanOperation(int id)
        {
            return await _departmanService.DeleteDepartmanOperation(id);
        }

    }
}