using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using System.Net.WebSockets;
using WebPortalStudent.Models;
using WebPortalStudent.Services;

namespace WebPortalStudent.Controllers
{
    public class TeacherController : BaseController<TeacherController>
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IS_TeacherSubject _teachersubject;
        private readonly IS_Grade _grade;

        public TeacherController(ILogger<HomeController> logger, IS_TeacherSubject teachersubject, IS_Grade grade)
        {
            _logger = logger;
            _teachersubject = teachersubject;
            _grade = grade;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _teachersubject.getListTeacherSubject(_accessToken);
            ViewBag.data = res.data;
            return View();
        }
        public async Task<IActionResult>Grade()
        {
            var resGrade = await _grade.getListGrade(_accessToken);
            ViewBag.dataGrade=resGrade.data;
            
            return View();
        }
    }
}
