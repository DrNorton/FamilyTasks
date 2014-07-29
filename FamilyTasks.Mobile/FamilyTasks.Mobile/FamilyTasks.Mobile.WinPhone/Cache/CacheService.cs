using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Core.Base;
using FamilyTasks.Mobile.Api.Request;

namespace FamilyTasks.Mobile.WinPhone.Cache
{
    public class CacheService:ICacheService
    {
        public T GetCachedResult<T>(BaseRequest request)
        {
            return default(T);
        }

        public void SaveCacheResult<T>(BaseRequest request, T result)
        {
            
        }
    }
}
