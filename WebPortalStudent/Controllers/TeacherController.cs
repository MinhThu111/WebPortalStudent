using Microsoft.AspNetCore.Mvc;

namespace WebPortalStudent.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
