using WebPortalStudent.Lib;
using WebPortalStudent.Models;
using System;

namespace WebPortalStudent.Services
{
    public interface IS_NewsCategory
    {
        Task<ResponseData<List<M_NewsCategory>>> getListNewsCategory(string accessToken);
        Task<ResponseData<M_NewsCategory>> getNewsCategoryById(string accessToken, int id);
        Task<ResponseData<List<M_NewsCategory>>> getNewCategoryMenu(string accessToken);

    }
    public class S_NewsCategory : IS_NewsCategory
    {
        private readonly ICallBaseApi _callApi;
        public S_NewsCategory(ICallBaseApi callApi)
        {
            _callApi = callApi;
        }
        public async Task<ResponseData<List<M_NewsCategory>>> getListNewsCategory(string accessToken)
        {
            return await _callApi.GetResponseDataAsync<List<M_NewsCategory>>("/NewsCategory/getListNewsCategory", default(Dictionary<string, dynamic>), accessToken);
        }       
        public async Task<ResponseData<M_NewsCategory>> getNewsCategoryById(string accessToken, int id)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"id", id},
            };
            return await _callApi.GetResponseDataAsync<M_NewsCategory>("/NewsCategory/getNewsCategoryById", dictPars, accessToken);
        }
        public async Task<ResponseData<List<M_NewsCategory>>> getNewCategoryMenu(string accessToken)
        {
            return await _callApi.GetResponseDataAsync<List<M_NewsCategory>>("/NewsCategory/getNewCategoryMenu", default(Dictionary<string, dynamic>), accessToken);
        } 
       
    }
}
