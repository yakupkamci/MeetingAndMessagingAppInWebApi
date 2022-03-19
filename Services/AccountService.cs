using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace SahaBTMeet.Services
{
    public class AccountService : ControllerBase, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AppSettings _appSettings;
        private readonly IHttpContextAccessor _httpContext;
        public AccountService(IHttpContextAccessor httpContext,IAccountRepository accountRepository, IOptions<AppSettings> appSettings)
        {
            _accountRepository = accountRepository;
            _appSettings = appSettings.Value;
            _httpContext = httpContext;
        }

        public async Task<ActionResult<AccountDTO>> DeactivateAccountOperation(int Id)
        {
            try
            {
                Account InComingAccount = await _accountRepository.GetAccountByIdOperation(Id);
                if (InComingAccount != null)
                {
                    return Ok((await _accountRepository.DeactivateAccountOperation(InComingAccount)).AccountToAccountDTO());
                }
                return BadRequest("Pasif Edilecek Hesap Kayitli Degildir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Baglantinizi Kontrol Ediniz...");
            }
        }

        public async Task<ActionResult<AccountDTO>> CreateAccountOperation(Account Account)
        {
            try
            {
                Account InComingAccount = await _accountRepository.GetAccountByEmailOperation(Account.Email);
                if (InComingAccount != null)
                {
                    return BadRequest("Girmiş Olduğunuz Account Kayıtlıdır !!!");
                }
                await _accountRepository.CreateAccountOperation(Account);
                return Ok(Account.AccountToAccountDTO());
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Baglantinizi Kontrol Ediniz...");
            }

        }

        public async Task<ActionResult<AccountDTO>> GetAccountByEmailOperation(string Email)
        {
            try
            {
                var inComing = (await _accountRepository.GetAccountByEmailOperation(Email)).AccountToAccountDTO();
                if (inComing.Email == null)
                {
                    return Ok("Kayıtlı Kullanıcı Mevcut Değildir !!!");
                }
                return Ok(inComing);
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Baglantinizi Kontrol Ediniz...");
            }
        }

        public JwtAccountDTO GetAccountById(int Id)
        {
            try
            {
                var coming = _accountRepository.GetAccountById(Id);
                return coming;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        public async Task<ActionResult<AccountDTO>> GetAccountByIdOperation(int Id)
        {
            try
            {
                var inComing = (await _accountRepository.GetAccountByIdOperation(Id)).AccountToAccountDTO();
                if (inComing.Email == null)
                {
                    return Ok("Kayıtlı Kullanıcı Mevcut Değildir !!!");
                }
                return Ok(inComing);
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Baglantinizi Kontrol Ediniz...");
            }
        }

        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAllAccountOperation()
        {
            try
            {
                return Ok((await _accountRepository.GetAllAccountOperation()).AccountToAccountDTO());
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Ex=> "+ex.Message);
            }

        }

        public async Task<ActionResult<AccountDTO>> UpdateAccountOperation(Account Account)
        {            
            try
            {
                JwtAccountDTO httpAccount =(JwtAccountDTO) _httpContext.HttpContext.Items["Account"];
                Account InComingAccount = await _accountRepository.GetAccountByIdOperation(httpAccount.Id);
                if (InComingAccount != null)
                {
                    if (InComingAccount.Email != Account.Email)
                    {
                        Account InComingAccountByEmail = await _accountRepository.GetAccountByEmailOperation(Account.Email);
                        if (InComingAccountByEmail == null)
                        {
                            return Ok((await _accountRepository.UpdateAccountOperation(InComingAccount, Account)).AccountToAccountDTO());
                        }
                        return BadRequest("Belirlediginiz Yeni Email Baska Kullanici Tarafindan Kullanilmaktadir !!!");
                    }
                    return Ok((await _accountRepository.UpdateAccountOperation(InComingAccount, Account)).AccountToAccountDTO());
                }
                return BadRequest("Guncellemek Istediginiz Kullanici Kayitli Degildir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Baglantinizi Kontrol Ediniz...");
            }
        }

        public async Task<ActionResult<AccountDTO>> RoleAssignmentToAccountOperation(string Email, List<Role> Role)
        {
            try
            {
                Account InComingAccount = await _accountRepository.GetAccountByEmailOperation(Email);
                if (InComingAccount != null)
                {
                    return Ok((await _accountRepository.RoleAssignmentToAccountOperation(InComingAccount, Role)).AccountToAccountDTO());
                }
                return BadRequest("Rol Atamak Istediginiz Hesap Kayitli Degildir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!!" + ex.Message);
            }
        }

        public async Task<ActionResult<AccountDTO>> ChangeAccountIsBlockedOperation(string Email)
        {
            try
            {
                Account InComingAccount = await _accountRepository.GetAccountByEmailOperation(Email);
                if (InComingAccount != null)
                {
                    return Ok((await _accountRepository.ChangeAccountIsBlockedOperation(InComingAccount)).AccountToAccountDTO());
                }
                return BadRequest("Bloke Edilecek Hesap Kayitli Degildir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!!" + ex.Message);
            }
        }

        public async Task<ActionResult<AccountDTO>> RoleRemoveToAccountOperation(string Email, List<Role> Role)
        {
            try
            {
                Account InComingAccount = await _accountRepository.GetAccountByEmailOperation(Email);
                if (InComingAccount != null)
                {
                    return Ok((await _accountRepository.RoleRemoveToAccountOperation(InComingAccount, Role)).AccountToAccountDTO());
                }
                return BadRequest("Rol Silmek Istediginiz Hesap Kayitli Degildir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Baglantinizi Kontrol Ediniz...");
            }
        }

        public async Task<ActionResult<AccountDTO>> ActivateAccountOperation(int Id)
        {
            try
            {
                Account InComingAccount = await _accountRepository.GetAccountByIdOperation(Id);
                if (InComingAccount != null)
                {
                    return Ok((await _accountRepository.ActivateAccountOperation(InComingAccount)).AccountToAccountDTO());
                }
                return BadRequest("Aktif Edilecek Hesap Kayitli Degildir !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hay Aksi Bir Sorunla Karsilasildi !!! Baglantinizi Kontrol Ediniz...");
            }
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest Model)
        {
            var account = _accountRepository.GetAccountByEmailAndPasswordOperation(Model.Email, Model.Password);

            if (account == null) return null;

            var token = generateJwtToken(account);

            return new AuthenticateResponse(account, token);
        }

        private string generateJwtToken(Account Account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", Account.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}