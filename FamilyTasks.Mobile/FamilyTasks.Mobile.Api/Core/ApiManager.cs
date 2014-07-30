using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.Api.Response;

namespace FamilyTasks.Mobile.Api.Core
{
    public class ApiManager : IApiManager
    {
        private readonly IRequestExecuterService _requestExecuterService;

        public ApiManager(IRequestExecuterService requestExecuterService)
        {
            _requestExecuterService = requestExecuterService;
        }

        public async Task<Response<AutorizationResponse>> Autorizate(AutorizationRequest autorizationRequest)
        {
            return await _requestExecuterService.Autorization(autorizationRequest);
        }

        public async Task<Response<string>> Register(RegistrationRequest autorizationRequest)
        {
            return await _requestExecuterService.ExecuteRequest<string>(autorizationRequest);
        }
        public async Task<Response<List<ProjectResponse>>> GetProjectsList()
        {
            return await _requestExecuterService.ExecuteRequest<List<ProjectResponse>>(new GetProjectListRequest());
        }
    }
}
