using WebPortalStudent.Lib;
using WebPortalStudent.Models;
using System;

namespace WebPortalStudent.Services
{
    public interface IS_Grade
    {
        Task<ResponseData<List<M_Grade>>> getListGrade(string accessToken);
    }
    public class S_Grade : IS_Grade
    {
        private readonly ICallBaseApi _callApi;
        public S_Grade(ICallBaseApi callApi)
        {
            _callApi = callApi;
        }
        public async Task<ResponseData<List<M_Grade>>> getListGrade(string accessToken)
        {
            return await _callApi.GetResponseDataAsync<List<M_Grade>>("/Grade/getListGrade", default(Dictionary<string, dynamic>), accessToken);
        }
     
    }
}
