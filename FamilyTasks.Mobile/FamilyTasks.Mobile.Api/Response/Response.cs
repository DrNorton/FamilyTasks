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
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }

    }
}
