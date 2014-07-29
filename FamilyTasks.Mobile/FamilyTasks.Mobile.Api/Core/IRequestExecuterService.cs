using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.Api.Response;
using FamilyTasks.Mobile.Api.Settings;

namespace FamilyTasks.Mobile.Api.Core
{
    public interface IRequestExecuterService
    {
        Task<AutorizationResponse> Autorization(AutorizationRequest autorizationRequest);
        Task<T> ExecuteRequest<T>(BaseRequest request, bool useCache = false) where T : BaseRequest, new();
        bool IsAutorizated { get; }
    }
}