using System.Net.Http;
using Newtonsoft.Json;

namespace FamilyTasks.Mobile.Api.Request.Base
{
    public abstract class BaseRequest
    {
        [JsonIgnore]
        public abstract string MethodName { get; }
        [JsonIgnore]
        public abstract HttpMethod Method { get; }

        public string SerializeToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
