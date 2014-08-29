using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Dto.Users;

namespace FamilyTasks.Dto.Projects
{
    public class ProjectMemberDto
    {
        public long ProjectId { get; set; }
        public UserDto User { get; set; }
    }
}
