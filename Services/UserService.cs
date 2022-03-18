
namespace SahaBTMeet.Services
{
    public class UserService : ControllerBase, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ActionResult<UserDTO>> CreateUserOperation(User user)
        {
            try
            {
                User InComingUser = await _userRepository.GetUserByAccountId(user.AccountId);
                if(InComingUser != null)
                {
                   return BadRequest("Girmiş Olduğunuz Kullaniciya Ait Hesap Kayitli Degildir !!!"); 
                }
                return Ok((await _userRepository.CreateUserOperation(user)).UserToUserDTO());
            }catch(Exception ex){
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUserOperation()
        {
            try
            {
                var InComingUsers = (await _userRepository.GetAllUserOperation()).UserToUserDTO();
                if(InComingUsers != null)
                    return Ok(InComingUsers);
                else 
                    return Ok("Kayitli Kullanicilar Yoktur !!!");
            }catch(Exception ex){
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<UserDTO>> GetUserByAccountEmail(string email)
        {
            try
            {
                var InComingUser = (await _userRepository.GetUserByAccountEmail(email)).UserToUserDTO();
                if(InComingUser.Name != null)
                    return Ok(InComingUser);
                else 
                    return Ok("Hesaba Ait Kayitli Kullanici Yoktur !!!");                
            }catch(Exception ex){
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }

        }

        public async Task<ActionResult<UserDTO>> GetUserByAccountId(int id)
        {
            try
            {   
                var InComingUser = (await _userRepository.GetUserByAccountId(id)).UserToUserDTO();
                if(InComingUser.Name != null)
                    return Ok(InComingUser);
                else 
                    return Ok("Hesaba Ait Kayitli Kullanici Yoktur !!!");                
            }catch(Exception ex){
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            try
            {
                var InComingUser = (await _userRepository.GetUserById(id)).UserToUserDTO();
                if(InComingUser.Name != null)
                    return Ok(InComingUser);
                else 
                    return Ok("Kayitli Kullanici Yoktur !!!");
            }catch(Exception ex){
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByName(string name)
        {
            try
            {   
                var InComingUsers = (await _userRepository.GetUsersByName(name)).UserToUserDTO();
                if(InComingUsers != null)
                    return Ok(InComingUsers);
                else
                    return Ok(name+" Isimli Kullanicilar Bulunamadi !!!");
            }catch(Exception ex){
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByNameAndSurname(string name, string surname)
        {
            try
            {
                var InComingUsers = (await _userRepository.GetUsersByNameAndSurname(name,surname)).UserToUserDTO();
                if(InComingUsers != null)
                    return Ok(InComingUsers);
                else
                    return Ok(name+" "+surname+" Isimli Kullanicilar Bulunamadi !!!");
            }catch(Exception ex){
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
        }

        public async Task<ActionResult<UserDTO>> UpdateUserOperation(int id, User user)
        {
            try
            {
                User InComingUser = await _userRepository.GetUserById(id);
                if(InComingUser != null)
                {
                    return Ok((await _userRepository.UpdateUserOperation(id,user)).UserToUserDTO());
                }
                return BadRequest("Kayitli Kullanici Yoktur !!!");
            }catch(Exception ex){
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=>"+ex.Message);
            }
            
        }
    }
}