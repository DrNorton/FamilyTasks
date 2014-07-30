using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.Api.Response;

namespace FamilyTasks.Mobile.Api.Core
{
    public interface IApiManager
    {
        Task<Response<AutorizationResponse>> Autorizate(AutorizationRequest autorizationRequest);
        Task<Response<string>> Register(RegistrationRequest autorizationRequest);
        Task<Response<List<ProjectResponse>>> GetProjectsList();
    }
}