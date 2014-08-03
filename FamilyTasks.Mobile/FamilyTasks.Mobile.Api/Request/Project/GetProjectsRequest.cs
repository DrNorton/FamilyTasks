using System.Net.Http;
using FamilyTasks.Mobile.Api.Request.Base;

namespace FamilyTasks.Mobile.Api.Request.Project
{
    public class GetProjectsRequest:BaseRequest
    {
        public override string MethodName
        {
            get { return "api/Project/Projects"; }
        }


        public override System.Net.Http.HttpMethod Method
        {
            get { return HttpMethod.Get;}
        }
    }
}
