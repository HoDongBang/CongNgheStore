using BackEndApi.Model;
using BackEndApi.Repositories;
using CongNgheStore.Models;
using CongNgheStore.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BackEndApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(IAccountRepository accountRepository, IConfiguration configuration,
            SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody]SignInVM signInVM)
        {
            try
            {
                if (signInVM == null)
                    return StatusCode(StatusCodes.Status400BadRequest);
                
                var user = await _accountRepository.SignIn(signInVM);
                if (user != null)
                    return Ok(new ApiResponse
                    {
                        Success = true,
                        Message = "Đăng nhập thành công!",
                        Data = await GenerateToken(user)
                    });

                return Ok(new ApiResponse
                {
                    Success = false,
                    Message = "Số điện thoại hoặc mật khẩu không hợp lệ"
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private async Task<string> GenerateToken(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("Id", user.Id.ToString()),
                    //role
                    //new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                    new Claim(ClaimTypes.Role, string.Join(";",roles)),

                    new Claim("TokenId", Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpVM signUpVM)
        {
            try
            {
                if (signUpVM == null)
                    return StatusCode(StatusCodes.Status400BadRequest);

                var result = await _accountRepository.SignUpUser(signUpVM);
                if (result == true)
                    return Ok(new ApiResponse
                    {
                        Success = true,
                        Message = "Authenicate success"
                    });

                return Ok(new ApiResponse
                {
                    Success = false,
                    Message = "Tài khoản đã được đăng ký trước đó!"
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            try
            {
                _accountRepository.SignOut();
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Bạn đã đăng xuất"
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
