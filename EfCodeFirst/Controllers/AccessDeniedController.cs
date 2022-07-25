using Microsoft.AspNetCore.Mvc;

namespace EfCodeFirst.Controllers
{
    public class AccessDeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
