using Microsoft.AspNetCore.Mvc;

namespace WebPortalStudent.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
