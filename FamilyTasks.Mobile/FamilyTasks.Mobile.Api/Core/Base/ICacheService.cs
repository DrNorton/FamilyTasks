using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.Api.Request.Base;
using FamilyTasks.Mobile.Api.Response;

namespace FamilyTasks.Mobile.Api.Core.Base
{
    public interface ICacheService
    {
        Response<T> GetCachedResult<T>(BaseRequest request);
        void SaveCacheResult<T>(BaseRequest request, T result);
    }
}