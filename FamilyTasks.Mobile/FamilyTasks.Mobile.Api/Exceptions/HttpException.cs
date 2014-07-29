using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTasks.Mobile.Api.Exceptions
{
    public class HttpException:Exception
    {
        private readonly HttpStatusCode _httpCode;

        public HttpException(HttpStatusCode httpCode,string message)
            :base(message)
        {
            _httpCode = httpCode;
        }

        public HttpException(HttpStatusCode httpCode, string message, Exception innerException)
            : base(message,innerException)
        {
            _httpCode = httpCode;
        }

        public HttpStatusCode HttpCode
        {
            get { return _httpCode; }
        }
    }
}
