using WebPortalStudent.Lib;
using WebPortalStudent.Models;
using System;

namespace WebPortalStudent.Services
{
    public interface IS_News
    {
        Task<ResponseData<List<M_News>>> getListNews(string accessToken);
        Task<ResponseData<List<M_News>>> getListNewsByCategoryId(string accessToken, int id);
        Task<ResponseData<M_News>> getNewsById(string accessToken, int id);
        //Task<ResponseData<List<M_Count>>> getCountNewsByNewsType(string accessToken);
        //Task<ResponseData<List<M_News>>> getListNewsByConditionSequenceStatus(string accessToken, string sequenceStatus, string name, DateTime? fdate, DateTime? tdate);
        //Task<ResponseData<List<M_News>>> getListNewsBySequenceStatus(string accessToken, string sequenceStatus, string lstNewstypeid);


        //Task<ResponseData<M_News>> Create(string accessToken, EM_News model, string createdBy);
        //Task<ResponseData<M_News>> Update(string accessToken, EM_News model, string updatedBy);
        //Task<ResponseData<M_News>> Delete(string accessToken, int id, string updatedBy);
        //Task<ResponseData<M_News>> UpdateStatus(string accessToken, int id, int status, DateTime? timer, string updatedBy);
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
        public async Task<ResponseData<List<M_News>>> getListNewsByCategoryId(string accessToken, int id)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"newcategoryid", id},
            };
            return await _callApi.GetResponseDataAsync<List<M_News>>("/News/getListNewsByCategoryId", dictPars, accessToken);
        }
        public async Task<ResponseData<M_News>> getNewsById(string accessToken, int id)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"id", id},
            };
            return await _callApi.GetResponseDataAsync<M_News>("/News/getNewsById", dictPars, accessToken);
        }
        //public async Task<ResponseData<List<M_Count>>> getCountNewsByNewsType(string accessToken)
        //{
        //    return await _callApi.GetResponseDataAsync<List<M_Count>>("/News/getCountNewsByNewsType", default(Dictionary<string, dynamic>), accessToken);
        //}
        //public async Task<ResponseData<List<M_News>>> getListNewsByConditionSequenceStatus(string accessToken, string sequenceStatus, string name, DateTime? fdate, DateTime? tdate)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"sequenceStatus", sequenceStatus},
        //        {"name", name},
        //        {"fdate", fdate?.ToString("O")},
        //        {"tdate", tdate?.ToString("O")},
        //    };
        //    return await _callApi.GetResponseDataAsync<List<M_News>>("News/getListNewsByConditionSequenceStatus", dictPars, accessToken);
        //}
        //public async Task<ResponseData<List<M_News>>> getListNewsBySequenceStatus(string accessToken, string sequenceStatus, string lstNewstypeid)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"sequenceStatus", sequenceStatus},
        //        {"lstNewstypeid",lstNewstypeid }
        //    };
        //    return await _callApi.GetResponseDataAsync<List<M_News>>("/News/getListNewsBySequenceStatus", dictPars, accessToken);
        //}

        //public async Task<ResponseData<M_News>> Delete(string accessToken, int id, string updatedBy)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", id},
        //        {"updatedBy", updatedBy},
        //    };
        //    return await _callApi.DeleteResponseDataAsync<M_News>("/News/Delete", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_News>> UpdateStatus(string accessToken, int id, int status, DateTime? timer, string updatedBy)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", id},
        //        {"status", status},
        //        {"updatedBy", updatedBy},
        //        {"timer", timer?.ToString("O")},
        //    };
        //    return await _callApi.PutResponseDataAsync<M_News>("/News/UpdateStatus", dictPars, accessToken);
        //}
    }
}
