using WebPortalStudent.Lib;
using WebPortalStudent.Models;
using System;

namespace WebPortalStudent.Services
{
    public interface IS_Person
    {
        Task<ResponseData<M_Person>> getPersonById(string accessToken, int id);
        Task<ResponseData<List<M_Count>>> getCountPersonByPersonType(string accessToken);
        Task<ResponseData<List<M_Person>>> getListPersonBySequenceStatus(string accessToken, string sequenceStatus, string lstpersontypeid);

    }
    public class S_Person : IS_Person
    {
        private readonly ICallBaseApi _callApi;
        public S_Person(ICallBaseApi callApi)
        {
            _callApi = callApi;
        }
        public async Task<ResponseData<M_Person>> getPersonById(string accessToken, int id)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"id", id},
            };
            return await _callApi.GetResponseDataAsync<M_Person>("/Person/getPersonById", dictPars, accessToken);
        }
        public async Task<ResponseData<List<M_Count>>> getCountPersonByPersonType(string accessToken)
        {
            return await _callApi.GetResponseDataAsync<List<M_Count>>("/Person/getCountPersonByPersonType", default(Dictionary<string, dynamic>), accessToken);
        }
        public async Task<ResponseData<List<M_Person>>> getListPersonBySequenceStatus(string accessToken, string sequenceStatus, string lstpersontypeid)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"sequenceStatus", sequenceStatus},
                {"lstpersontypeid",lstpersontypeid }
            };
            return await _callApi.GetResponseDataAsync<List<M_Person>>("/Person/getListPersonBySequenceStatus", dictPars, accessToken);
        }
     
    }
}
