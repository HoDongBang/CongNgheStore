using Microsoft.AspNetCore.Mvc;

namespace CongNgheStore.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Check")]
        public IActionResult Check()
        {
            return View();
        }
    }
}
