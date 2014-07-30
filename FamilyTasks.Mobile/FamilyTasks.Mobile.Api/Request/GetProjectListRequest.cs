using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTasks.Mobile.Api.Request
{
    public class GetProjectListRequest:BaseRequest
    {
        public override string MethodName
        {
            get { return "api/Project/List"; }
        }

    }
}
