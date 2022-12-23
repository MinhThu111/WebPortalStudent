using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebPortalStudent.Models;
using WebPortalStudent.Services;

namespace WebPortalStudent.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IS_Person _person;
        private readonly IS_NewsCategory  _newscategory;

        public HomeController(ILogger<HomeController> logger, IS_Person person, IS_NewsCategory newscategory)
        {
            _logger = logger;
            _person = person;
            _newscategory = newscategory;
        }

        public async Task<IActionResult> Index()
        {
            var resTeacher = await _person.getListPersonBySequenceStatus(_accessToken, "1,0", "2");
            var resCount = await _person.getCountPersonByPersonType(_accessToken);
            ViewBag.CountData = resCount.data;
            ViewBag.SumData = resCount.data.Sum(x => x.count);
            ViewBag.data = resTeacher.data;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}