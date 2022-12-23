using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using WebPortalStudent.Lib;
using WebPortalStudent.Models;
using WebPortalStudent.Services;

namespace WebPortalStudent.Controllers
{
    public class CategoryController : BaseController<CategoryController>
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IS_News _news;
        private readonly IS_NewsCategory _newsCategory;

        public CategoryController(ILogger<HomeController> logger, IS_News news, IS_NewsCategory newsCategory)
        {
            _logger = logger;
            _news = news;
            _newsCategory = newsCategory;
        }

        public async Task<IActionResult> Index(int id)
        {
            ResponseData<List<M_News>> res = new ResponseData<List<M_News>>();
            string mess;
            if (id == 0)
            {
                res = await _news.getListNews(_accessToken);
                mess = "Tất cả tin";
            }
            else
            {
                res = await _news.getListNewsByCategoryId(_accessToken, id);
                var datas = (await _newsCategory.getNewsCategoryById(_accessToken, id)).data;
                mess = datas.Name;
            }

            ViewBag.dataNews = res.data;
            ViewBag.Name = mess;
            return View();
        }
        public async Task<IActionResult> NewsView(int id, int categoryid)
        {
            var resNewData = await _news.getNewsById(_accessToken, id);
            var resListNewData = await _news.getListNewsByCategoryId(_accessToken, categoryid);
            var resNewCategory = await _newsCategory.getNewCategoryMenu(_accessToken);
            ViewBag.dataNewsCategory = resNewCategory.data;
            ViewBag.resListNewData = resListNewData.data;
            ViewBag.resNewData = resNewData.data;
            return View();
        }
    }
}
