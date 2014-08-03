using System.Net.Http;
using FamilyTasks.Mobile.Api.Request.Base;

namespace FamilyTasks.Mobile.Api.Request.Task
{
    public class GetTasksByProjectIdRequest :BaseIdRequest
    {
        public override string MethodName
        {
            get { return "api/Task/TasksByProjectId"; }
        }
        public override System.Net.Http.HttpMethod Method
        {
            get {return HttpMethod.Get;}
        }
    }
}
