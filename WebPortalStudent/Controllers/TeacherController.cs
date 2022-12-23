using Microsoft.AspNetCore.Mvc;
using WebPortalStudent.Services;

namespace WebPortalStudent.Controllers
{
    public class TeacherController : BaseController<TeacherController>
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IS_Person _person;

        public TeacherController(ILogger<HomeController> logger, IS_Person person)
        {
            _logger = logger;
            _person = person;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _person.getListPersonBySequenceStatus(_accessToken, "1,0", "2");
            ViewBag.data = res.data;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult>P_View(int id)
        {
            return PartialView();
        }
    }
}
