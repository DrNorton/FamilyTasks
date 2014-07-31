using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FamilyTasks.Mobile.Api.Response
{
    public class Response<T>
    {
        private int _errorCode;
        private string _errorMessage;
        private T _result;

        public int ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public T Result
        {
            get { return _result; }
            set { _result = value; }
        }
    }
}
