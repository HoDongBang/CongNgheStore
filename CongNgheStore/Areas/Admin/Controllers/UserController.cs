using CongNgheStore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CongNgheStore.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        [Area("Admin")]
        public IActionResult SignIn()
        {
            return View(new SignInVM { RoleName = "Admin" });
        }
    }
}
