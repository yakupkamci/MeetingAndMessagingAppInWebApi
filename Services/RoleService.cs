
namespace SahaBTMeet.Services
{
    public class RoleService : ControllerBase,IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }

        public async Task<ActionResult<RoleDTO>> CreateRoleOperation(Role role)
        {
            try
            {
                Role InComingRole = await _roleRepository.GetRoleByName(role.Name);
                if (InComingRole != null)
                {
                    return Ok("Kayit Etmeye Calistiginiz Role Kayitlidir !!!");
                }
                await _roleRepository.CreateRoleOperation(role);
                return role.RoleToRoleDTO();
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<RoleDTO>> DeleteRoleOperation(int id)
        {
            try
            {
                Role InComingRole = await _roleRepository.GetRoleById(id);
                if (InComingRole != null)
                {
                    await _roleRepository.DeleteRoleOperation(InComingRole);
                    return Ok(InComingRole.RoleToRoleDTO());
                }
                return Ok("Girilen Role Kayitlarda Bulunamadi !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetAllRoleOperation()
        {
            try
            {
                var InComingRoles = (await _roleRepository.GetAllRoleOperation()).RoleToRoleDTO();
                if(InComingRoles != null)
                    return Ok(InComingRoles);
                else
                    return Ok("Kayitli Roller Bulunamadi !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<RoleDTO>> GetRoleById(int id)
        {
            try
            {
                var InComingRole = (await _roleRepository.GetRoleById(id)).RoleToRoleDTO();
                if(InComingRole.Name != null)
                    return Ok(InComingRole);
                else
                    return Ok("Kayitli Role Bulunamadi !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<RoleDTO>> GetRoleByName(string name)
        {
            try
            {
                var InComingRole = (await _roleRepository.GetRoleByName(name)).RoleToRoleDTO();
                if(InComingRole.Name != null)
                    return Ok(InComingRole);
                else
                    return Ok("Kayitli Role Bulunamadi !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<RoleDTO>> UpdateRoleOperation(string name, Role role)
        {
            try
            {
                Role InComingRoleByOldName = await _roleRepository.GetRoleByName(name);
                Role InComingRoleByNewName = await _roleRepository.GetRoleByName(role.Name);

                if (InComingRoleByOldName != null)
                {
                    if(InComingRoleByNewName == null)
                        return Ok((await _roleRepository.UpdateRoleOperation(name, role)).RoleToRoleDTO());
                    else
                        return BadRequest("Girmis Oldugunuz Yeni Rol Kayitlidir !!!");
                }
                return BadRequest("Girmis Oldugunuz Rol Kayitli Degildir !!!");

            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }
    }
}