using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Request.Base;
using Newtonsoft.Json;

namespace FamilyTasks.Mobile.Api.Request
{
    public class RegistrationRequest:BaseRequest
    {
        public override string MethodName
        {
            get { return "api/Account/Register"; }
        }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("confirmPassword")]
        public string ConfirmPassword { get; set; }

        public override System.Net.Http.HttpMethod Method
        {
            get { return HttpMethod.Post;}
        }
    }
}
