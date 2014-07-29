using System;
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
        private readonly ISettings _settings;
        private RestClient _client;
        private Token _token;

        public RequestExecuterService(ISettings settings)
        {
            _settings = settings;
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
            _client = new RestClient(_settings.BaseUrl);
            _client.AddHandler("application/json", new JsonDeserializer());
            GetTokenFromStorage();
        }
        public async Task<AutorizationResponse> Autorization(AutorizationRequest autorizationRequest)
        {
            var result=await GetNewTokenFromApi(autorizationRequest);
            SaveTokenToStorage(result);
            return result;
        }
        public async Task<T> ExecuteRequest<T>(BaseRequest request)
        {
            var jsonParam = request.SerializeToJson();
            var restRequest = GetRequestAndPrepareWithToken(request.MethodName);
            restRequest.AddParameter("", jsonParam);
            return await Execute<T>(restRequest);
        }
        private async Task<AutorizationResponse> GetNewTokenFromApi(AutorizationRequest autorizationRequest)
        {
            var request = new RestRequest("/token", HttpMethod.Post);
            request.AddParameter("grant_type", "password");
            request.AddParameter("userName", autorizationRequest.UserName);
            request.AddParameter("password", autorizationRequest.Password);
         
           
            return await Execute<AutorizationResponse>(request);
        }


        private async Task<T> Execute<T>(IRestRequest restRequest)
        {
            try
            {
                var response = await _client.Execute<T>(restRequest);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Data;
                }
                else
                {
                    throw new HttpException(response.StatusCode, response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.Conflict, e.Message.ToString(), e);
            }
        }

        private IRestRequest GetRequestAndPrepareWithToken(string method)
        {
            var request = new RestRequest(method);
            request.AddHeader("Autorization", String.Format("{0} {1}", Token.TokenType, Token.Value));
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            return request;
        }

        private void SaveTokenToStorage(AutorizationResponse response)
        {
            _settings.Token = new Token() { Value = response.AccessToken, ExpiredIn = response.ExpiresIn, TokenType = response.TokenType };
        }
        private void GetTokenFromStorage()
        {
            _token = _settings.Token;
        }


        public Task<T> ExecuteRequest<T>(BaseRequest request, bool useCache = false) where T : BaseRequest, new()
        {
            throw new NotImplementedException();
        }

       
    }

    
}
