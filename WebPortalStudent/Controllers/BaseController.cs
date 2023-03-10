using WebPortalStudent.Models;
using WebPortalStudent.Services;
using WebPortalStudent.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.String;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using WebPortalStudent.Lib;

namespace WebPortalStudent.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        private IHttpContextAccessor httpContextAccessor;
        private string supplierId = Empty;
        private string accessToken = Empty;
        private string userId = Empty;
        private IMapper mapper;
        private IMemoryCache memoryCache;
        protected IMemoryCache _memoryCache => memoryCache ?? (memoryCache = HttpContext?.RequestServices.GetService<IMemoryCache>());
        protected IMapper _mapper => mapper ?? (mapper = HttpContext?.RequestServices.GetService<IMapper>());

        protected IHttpContextAccessor _httpContextAccessor => httpContextAccessor ?? (httpContextAccessor = HttpContext?.RequestServices.GetService<IHttpContextAccessor>());

        protected string _accessToken => IsNullOrEmpty(accessToken) ? (accessToken = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "AccessToken")?.Value) : accessToken;

        protected string _userId => IsNullOrEmpty(userId) ? (userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value) : userId;

        protected string _supplierId => IsNullOrEmpty(supplierId) ? (supplierId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "SupplierId")?.Value) : supplierId;

    
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_memoryCache.TryGetValue("news_category_menu", out ResponseData<List<M_NewsCategory>> newsCategory))
            {
                newsCategory = HttpContext?.RequestServices.GetService<IS_NewsCategory>().getNewCategoryMenu(_accessToken).Result;
                if (newsCategory.result == 1 && newsCategory.data != null)
                {
                    MemoryCacheEntryOptions cacheExpiryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(10),
                        Priority = CacheItemPriority.Normal,
                        //SlidingExpiration = TimeSpan.FromMinutes(5),
                        Size = 1024
                    };
                    _memoryCache.Set("news_category_menu", newsCategory, cacheExpiryOptions);
                }
            }
            //ViewBag.Newscategory = newsCategory.data ?? new List<M_NewsCategory>();
            ////ViewBag.SupplierInfo = newsCategory.data ?? new List<M_NewsCategory>();

            var resNewCategory = (ResponseData<List<M_NewsCategory>>)_memoryCache.Get("news_category_menu");
            ViewBag.Newscategory = resNewCategory.data;
            base.OnActionExecuting(context);
        }

    }
}
