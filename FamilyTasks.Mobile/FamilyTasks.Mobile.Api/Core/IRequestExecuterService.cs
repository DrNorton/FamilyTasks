using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.Api.Response;
using FamilyTasks.Mobile.Api.Settings;

namespace FamilyTasks.Mobile.Api.Core
{
    public interface IRequestExecuterService
    {
        Task<Response<AutorizationResponse>> Autorization(AutorizationRequest autorizationRequest);
        Task<Response<T>> ExecuteRequest<T>(BaseRequest request, bool useCache = false);
        bool IsAutorizated { get; }
    }
}