using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTasks.Mobile.Api.Request.Base
{
    public abstract class BaseIdRequest:BaseRequest
    {
        public long Identity { get; set; }
    }
}
