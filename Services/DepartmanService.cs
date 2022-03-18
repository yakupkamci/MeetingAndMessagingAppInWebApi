
namespace SahaBTMeet.Services
{
    public class DepartmanService : ControllerBase,IDepartmanService
    {
        private readonly IDepartmanRepository _departmanRepository;
        public DepartmanService(IDepartmanRepository departmanRepository)
        {
            _departmanRepository = departmanRepository;
        }

        public async Task<ActionResult<DepartmanDTO>> CreateDepartmanOperation(Departman departman)
        {
            try
            {
                Departman InComingDepartman = await _departmanRepository.GetDepartmanByName(departman.Name);
                if (InComingDepartman != null)
                {
                    return BadRequest("Kayit Edilecek Departman Db' de Kayitlidir !!!");
                }
                return Ok((await _departmanRepository.CreateDepartmanOperation(departman)).DepartmanToDTO());
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<DepartmanDTO>> DeleteDepartmanOperation(int id)
        {
            try
            {
                Departman departman = await _departmanRepository.GetDepartmanById(id);
                if(departman != null)
                {
                   return Ok((await _departmanRepository.DeleteDepartmanOperation(departman)).DepartmanToDTO());
                }
                 return NotFound("Silmek Istediginiz Departman Db' de Mevcut Degildir !!!");              
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<DepartmanDTO>>> GetAllDepartmanOperation()
        {
            try
            {
                var InComingDepartmans = (await _departmanRepository.GetAllDepartmanOperation());
                if(InComingDepartmans != null)
                    return Ok(InComingDepartmans.DepartmanToDTO());
                else
                    return Ok("Db' de Kayitli Departman Bulunmamaktadir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<DepartmanDTO>> GetDepartmanById(int id)
        {
            try
            {
                var InComingDepartman = (await _departmanRepository.GetDepartmanById(id)).DepartmanToDTO();
                if(InComingDepartman.Name != null)
                    return Ok(InComingDepartman);
                else
                    return Ok("Db' de Kayitli Departman Bulunmamaktadir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<DepartmanDTO>> GetDepartmanByName(string name)
        {
            try
            {
                var InComingDepartman = (await _departmanRepository.GetDepartmanByName(name.Replace("-"," "))).DepartmanToDTO();
                if(InComingDepartman.Name != null)
                    return Ok(InComingDepartman);
                else
                    return Ok("Db' de Kayitli Departman Bulunmamaktadir !!!"); 
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<DepartmanDTO>> UpdateDepartmanOperation(string name, Departman departman)
        {
            try
            {
                Departman InComingOldName = await _departmanRepository.GetDepartmanByName(name.Replace("-"," "));
                Departman InComingNewName = await _departmanRepository.GetDepartmanByName(departman.Name);
                if(InComingOldName != null)
                {
                    if(InComingNewName == null)                    
                        return Ok((await _departmanRepository.UpdateDepartmanOperation(name.Replace("-"," "),departman)).DepartmanToDTO());
                    else
                        return Ok("Girmis Oldugunuz Yeni Departman Db' de Kayitlidir !!!");
                }
                return NotFound("Guncellemek Istediginiz Departman Db' de Mevcut Degildir !!!");  
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
            
        }
    }
}