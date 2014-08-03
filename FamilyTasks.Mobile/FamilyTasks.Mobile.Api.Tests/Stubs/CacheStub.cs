using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Core.Base;
using FamilyTasks.Mobile.Api.Request.Base;
using FamilyTasks.Mobile.Api.Response;

namespace FamilyTasks.Mobile.Api.Tests.Stubs
{
    public class CacheStub:ICacheService
    {
        public Response<T> GetCachedResult<T>(BaseRequest request)
        {
            return default(Response<T>);
        }

        public void SaveCacheResult<T>(BaseRequest request, T result)
        {
            return;
        }
    }
}
