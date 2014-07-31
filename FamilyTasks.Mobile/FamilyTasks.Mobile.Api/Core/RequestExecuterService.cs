using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Exceptions;
using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.Api.Response;
using FamilyTasks.Mobile.Api.Settings;
using RestSharp.Portable;
using RestSharp.Portable.Deserializers;

namespace FamilyTasks.Mobile.Api.Core
{
    public class RequestExecuterService : IRequestExecuterService
    {
        private readonly ISettingsService _settingsService;
        private IRestClient _client;
        private Token _token;

        public RequestExecuterService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
            _client =  new RestClient(_settingsService.BaseUrl);;
            Init();
        }

        public bool IsAutorizated
        {
            get { return _token!=null; }
        }
        public Token Token
        {
            get { return _token; }
        }
        private void Init()
        {
         
            _client.AddHandler("application/json", new JsonDeserializer());
            GetTokenFromStorage();
        }
        public async Task<Response<AutorizationResponse>> Autorization(AutorizationRequest autorizationRequest)
        {
            var result=await GetNewTokenFromApi(autorizationRequest);
            if (result.ErrorCode == 0) //Если успешно сохраняем
            {
                SaveTokenToStorage(result.Result);
            }
            
            return result;
        }
        private async Task<Response<AutorizationResponse>> GetNewTokenFromApi(AutorizationRequest autorizationRequest)
        {
            var request = new RestRequest("/token", HttpMethod.Post);
            request.AddParameter("grant_type", "password");
            request.AddParameter("userName", autorizationRequest.UserName);
            request.AddParameter("password", autorizationRequest.Password);

            try
            {
                var result = await ExecuteAutorization<AutorizationResponse>(request);
                return result;
            }
            catch (Exception e)
            {
                return new Response<AutorizationResponse>(){ErrorCode = 100,ErrorMessage = String.Format("Внутренняя ошибка: {0}",e.Message)};
            }
        }
        private async Task<Response<T>> Execute<T>(IRestRequest restRequest)
        {
            try
            {
                var response = await _client.Execute<Response<T>>(restRequest);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Data;
                }
                else
                {
                    return new Response<T>() {ErrorCode = 1000, ErrorMessage = "Внутренняя ошибка"};
                  
                }
            }
            catch (Exception e)
            {
                return new Response<T>() { ErrorCode = 10000, ErrorMessage = e.Message };
            }
        }
        private async Task<Response<T>> ExecuteAutorization<T>(IRestRequest restRequest)
        {
            try
            {
                var response = await _client.Execute<T>(restRequest);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return new Response<T>(){ErrorCode = 0,ErrorMessage = "",Result = response.Data};
                }
                else
                {
                    return new Response<T>() { ErrorCode = 10000, ErrorMessage = response.StatusCode.ToString()};
                }
            }
            catch (Exception e)
            {
                 return new Response<T>() { ErrorCode = 10000, ErrorMessage = e.Message};
            }
        }
        private IRestRequest GetRequestAndPrepareWithToken(string method)
        {
            var request = new RestRequest(method);
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            if (Token != null) { request.AddHeader("Authorization", String.Format("{0} {1}", "Bearer", Token.Value)); }
            return request;
        }
        private void SaveTokenToStorage(AutorizationResponse response)
        {
            _settingsService.Token = new Token() { Value = response.AccessToken, ExpiredIn = response.ExpiresIn, TokenType = response.TokenType };
            _token = _settingsService.Token;
        }
        private void GetTokenFromStorage()
        {
            _token = _settingsService.Token;
        }
        public async Task<Response<T>> ExecuteRequest<T>(BaseRequest request, bool useCache = false)
        {
            var restRequest = GetRequestAndPrepareWithToken(request.MethodName);
            restRequest.Method=HttpMethod.Post;
         
            restRequest.AddParameter("application/json", request, ParameterType.RequestBody);
            
            Debug.WriteLine("отправлен запрос {0}",_client.BuildUrl(restRequest).AbsoluteUri);
            return await Execute<T>(restRequest);
        }
    }

    
}
