using FamilyTasks.Mobile.Api.Request;

namespace FamilyTasks.Mobile.Api.Core.Base
{
    public interface ICacheService
    {
        T GetCachedResult<T>(BaseRequest request);
        void SaveCacheResult<T>(BaseRequest request, T result);
    }
}