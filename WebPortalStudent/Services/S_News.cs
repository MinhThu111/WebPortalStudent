using WebPortalStudent.Lib;
using WebPortalStudent.Models;
using System;

namespace WebPortalStudent.Services
{
    public interface IS_News
    {
        Task<ResponseData<List<M_News>>> getListNews(string accessToken);
        Task<ResponseData<M_News>> getNewsById(string accessToken, int id);
        Task<ResponseData<List<M_News>>> getListNewsByCategoryId(string accessToken, int id);
    }
    public class S_News : IS_News
    {
        private readonly ICallBaseApi _callApi;
        public S_News(ICallBaseApi callApi)
        {
            _callApi = callApi;
        }
        public async Task<ResponseData<List<M_News>>> getListNews(string accessToken)
        {
            return await _callApi.GetResponseDataAsync<List<M_News>>("/News/getListNews", default(Dictionary<string, dynamic>), accessToken);
        }
        public async Task<ResponseData<M_News>> getNewsById(string accessToken, int id)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"id", id},
            };
            return await _callApi.GetResponseDataAsync<M_News>("/News/getNewsById", dictPars, accessToken);
        }
        public async Task<ResponseData<List<M_News>>> getListNewsByCategoryId(string accessToken, int id)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"newcategoryid", id},
            };
            return await _callApi.GetResponseDataAsync<List<M_News>>("/News/getListNewsByCategoryId", dictPars, accessToken);
        }
    }
}
