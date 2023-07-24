using CongNgheStore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CongNgheStore.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [Route("SignIn")]
        public IActionResult SignIn()
        {
            return View(new SignInVM { RoleName = "User"});
        }

        [Route("SignUp")]
        public IActionResult SignUp()
        {
            return View(new SignUpVM { RoleName = "User"});
        }

    }
}
