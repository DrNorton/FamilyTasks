using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTasks.Mobile.Api.Response
{
    public class ProjectMemberResponse
    {
        public long ProjectId { get; set; }
        public UserResponse User { get; set; }
    }
}
