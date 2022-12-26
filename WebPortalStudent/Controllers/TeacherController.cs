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
        //private readonly IS_Person _person;
        private readonly IS_TeacherSubject _teachersubject;
        private readonly IS_Subject _subject;

        public TeacherController(ILogger<HomeController> logger, IS_TeacherSubject teachersubject, IS_Subject subject)
        {
            _logger = logger;
            _teachersubject = teachersubject;
            _subject = subject;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _teachersubject.getListTeacherSubject(_accessToken);
            var resSubject= await _subject.getListSubject(_accessToken);
            ViewBag.subject = resSubject.data;
            ViewBag.data = res.data;
            return View();
        }
        public async Task<IActionResult>Subject(int id,string name)
        {
            var res = await _teachersubject.getListTeacherByIdSubject(_accessToken, id);
            var resSubject = await _subject.getListSubject(_accessToken);
            ViewBag.subject = resSubject.data;
            ViewBag.data = res.data;
            return View();
        }
    }
}
