using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using WebPortalStudent.Lib;
using WebPortalStudent.Models;
using WebPortalStudent.Services;

namespace WebPortalStudent.Controllers
{
    public class NewsController : BaseController<NewsController>
    {
        private readonly IS_News _news;
        private readonly IS_NewsCategory _newsCategory;

        public NewsController(IS_News news, IS_NewsCategory newsCategory)
        {
            _news = news;
            _newsCategory = newsCategory;
        }

        public async Task<IActionResult> Index(int category)
        {
            ResponseData<List<M_News>> res = new ResponseData<List<M_News>>();
            string mess;
            if (category == 0)
            {
                res = await _news.getListNews(_accessToken);
                mess = "Tất cả tin";
            }
            else
            {
                res = await _news.getListNewsByCategoryId(_accessToken, category);
                var datas = (await _newsCategory.getNewsCategoryById(_accessToken, category)).data;
                mess = datas.Name;
            }
            var resNewCategory = (ResponseData<List<M_NewsCategory>>)_memoryCache.Get("news_category_menu");
            ViewBag.dataNewsCategory = resNewCategory.data;
            ViewBag.dataNews = res.data;
            ViewBag.Name = mess;
            return View();
        }
        public async Task<IActionResult> Detail(string titleSlug, int id)
        {
            var res = await _news.getNewsById(_accessToken, id);
            if (res.result != 1 || res.data == null)
                return RedirectToAction("Index","Error");   //tao controller 404, task
            var resListNewData = await _news.getListNewsByCategoryId(_accessToken, res.data.newscategoryid.Value);  
            var resNewCategory = (ResponseData<List<M_NewsCategory>>)_memoryCache.Get("news_category_menu");
            ViewBag.dataNewsCategory = resNewCategory.data;
            ViewBag.resListNewData = resListNewData.data;
            ViewBag.resNewData = res.data;
            return View();
        }
    }
}
