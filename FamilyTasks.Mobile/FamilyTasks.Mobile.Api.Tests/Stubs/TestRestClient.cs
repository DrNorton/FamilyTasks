using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Portable;

namespace FamilyTasks.Mobile.Api.Tests.Stubs
{
    public class TestRestClient:IRestClient
    {
        private Uri _baseUrl;

        public IRestClient AddEncoding(string encodingId, RestSharp.Portable.Encodings.IEncoding encoding)
        {
            throw new NotImplementedException();
        }

        public IRestClient AddHandler(string contentType, RestSharp.Portable.Deserializers.IDeserializer deserializer)
        {
            throw new NotImplementedException();
        }

        public RestSharp.Portable.Authenticators.IAuthenticator Authenticator
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Uri BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        public IRestClient ClearEncodings()
        {
            throw new NotImplementedException();
        }

        public IRestClient ClearHandlers()
        {
            throw new NotImplementedException();
        }

        public System.Net.CookieContainer CookieContainer
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<Parameter> DefaultParameters
        {
            get { throw new NotImplementedException(); }
        }

        public Task<IRestResponse<T>> Execute<T>(IRestRequest request)
        {
            return null;
        }

        public Task<IRestResponse> Execute(IRestRequest request)
        {
            throw new NotImplementedException();
        }

        public RestSharp.Portable.Encodings.IEncoding GetEncoding(IEnumerable<string> encodingIds)
        {
            throw new NotImplementedException();
        }

        public RestSharp.Portable.Deserializers.IDeserializer GetHandler(string contentType)
        {
            throw new NotImplementedException();
        }

        public bool IgnoreResponseStatusCode
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Net.IWebProxy Proxy
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IRestClient RemoveEncoding(string encodingId)
        {
            throw new NotImplementedException();
        }

        public IRestClient RemoveHandler(string contentType)
        {
            throw new NotImplementedException();
        }

        public IRestClient ReplaceHandler(Type oldType, RestSharp.Portable.Deserializers.IDeserializer deserializer)
        {
            throw new NotImplementedException();
        }
    }
}
