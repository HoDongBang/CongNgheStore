using CongNgheStore.Models;
using CongNgheStore.Models.DbContext_Folder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CongNgheStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly CongNgheStoreDBContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public ValuesController(CongNgheStoreDBContext context,
            SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpPost("Aa")]
        public async Task<IActionResult> Aa()
        {
            try
            {
                var admin = new User
                {
                    UserName = "0900100100",
                    FirstName = "Hồ Minh",
                    LastName = "Thiện",
                    PhoneNumber = "0900100100"
                };

                var user = new User
                {
                    UserName = "0900200200",
                    FirstName = "Hồ Minh",
                    LastName = "Thiện",
                    PhoneNumber = "0900200200"
                };
                try
                {
                    var adminResult = await _userManager.CreateAsync(admin, "Admin@123");
                    var userResult = await _userManager.CreateAsync(user, "User@123");
                }   
                catch (Exception ex)
                {
                    return Ok(ex);
                }
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
