using Microsoft.AspNetCore.Mvc;

namespace WebPortalStudent.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
