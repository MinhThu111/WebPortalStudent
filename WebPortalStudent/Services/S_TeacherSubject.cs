using WebPortalStudent.Lib;
using WebPortalStudent.Models;
using System;

namespace WebPortalStudent.Services
{
    public interface IS_TeacherSubject
    {
        Task<ResponseData<List<M_TeacherSubject>>> getListTeacherSubject(string accessToken);
        Task<ResponseData<List<M_TeacherSubject>>> getListTeacherByIdSubject(string accessToken, int id);

    }
    public class S_TeacherSubject : IS_TeacherSubject
    {
        private readonly ICallBaseApi _callApi;
        public S_TeacherSubject(ICallBaseApi callApi)
        {
            _callApi = callApi;
        }
        public async Task<ResponseData<List<M_TeacherSubject>>> getListTeacherSubject(string accessToken)
        {
            return await _callApi.GetResponseDataAsync<List<M_TeacherSubject>>("/TeacherSubject/getListTeacherSubject", default(Dictionary<string, dynamic>), accessToken);
        }public async Task<ResponseData<List<M_TeacherSubject>>> getListTeacherByIdSubject(string accessToken, int id)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"id", id},
            };
            return await _callApi.GetResponseDataAsync<List<M_TeacherSubject>>("/TeacherSubject/getListTeacherByIdSubject", dictPars, accessToken);
        }

    }
    
}
