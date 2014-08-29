using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Request.Base;

namespace FamilyTasks.Mobile.Api.Request.ProjectMember
{
    public class GetProjectMembers : BaseIdRequest
    {
        public override string MethodName
        {
            get { return "api/ProjectMembers/Members"; }
        }


        public override System.Net.Http.HttpMethod Method
        {
            get { return HttpMethod.Get; }
        }
    }
}
