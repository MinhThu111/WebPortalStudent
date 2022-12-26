using WebPortalStudent.Lib;
using WebPortalStudent.Models;
using System;

namespace WebPortalStudent.Services
{
    public interface IS_Subject
    {
        Task<ResponseData<List<M_Subject>>> getListSubject(string accessToken);
    }
    public class S_Subject : IS_Subject
    {
        private readonly ICallBaseApi _callApi;
        public S_Subject(ICallBaseApi callApi)
        {
            _callApi = callApi;
        }
        public async Task<ResponseData<List<M_Subject>>> getListSubject(string accessToken)
        {
            return await _callApi.GetResponseDataAsync<List<M_Subject>>("/Subject/getListSubject", default(Dictionary<string, dynamic>), accessToken);
        }
     
    }
}
