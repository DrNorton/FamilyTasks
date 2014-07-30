using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Core.Base;
using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.Api.Response;
using FamilyTasks.Mobile.Api.Settings;
using RestSharp.Portable;

namespace FamilyTasks.Mobile.Api.Core
{
    public class RequestExecuterCachedServiceDecorator:IRequestExecuterService
    {
        private readonly ICacheService _cacheService;
        private readonly IRequestExecuterService _requestExecuterService;

        public bool IsAutorizated
        {
            get
            {
                return _requestExecuterService.IsAutorizated;
            }
        }

        public RequestExecuterCachedServiceDecorator(IRequestExecuterService requestExecuterService, ICacheService cacheService)
        {
            _cacheService = cacheService;
            _requestExecuterService = requestExecuterService;
        }

        public async Task<Response<AutorizationResponse>> Autorizate(AutorizationRequest autorizationRequest)
        {
            return await _requestExecuterService.Autorization(autorizationRequest);
        }

        public async Task<Response<T>> ExecuteRequest<T>(BaseRequest request, bool useCache=false) 
        {
            Response<T> result=default(Response<T>);
            if (useCache)
            {
                result = _cacheService.GetCachedResult<T>(request);
            }
            if (result == null)
            {
               result= await _requestExecuterService.ExecuteRequest<T>(request);
                //Сохраняем
                if (useCache)
                {
                   _cacheService.SaveCacheResult(request,result);
                }
            }
           
            return result;
        }


        public async Task<Response<AutorizationResponse>> Autorization(AutorizationRequest autorizationRequest)
        {
            return await _requestExecuterService.Autorization(autorizationRequest);
        }

       
    }
}
