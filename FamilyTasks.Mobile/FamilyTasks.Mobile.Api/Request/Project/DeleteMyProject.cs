using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Request.Base;

namespace FamilyTasks.Mobile.Api.Request.Project
{
    public class DeleteMyProject:BaseIdRequest
    {
        public override string MethodName
        {
            get { return "api/Project/DeleteMyProject"; }
        }

        public override System.Net.Http.HttpMethod Method
        {
            get { return HttpMethod.Post;}
        }
    }
}
