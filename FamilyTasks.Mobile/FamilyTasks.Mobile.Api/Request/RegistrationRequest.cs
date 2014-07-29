using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FamilyTasks.Mobile.Api.Request
{
    public class RegistrationRequest:BaseRequest
    {
        public override string MethodName
        {
            get { return "api/Account/Register"; }
        }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("confirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}
