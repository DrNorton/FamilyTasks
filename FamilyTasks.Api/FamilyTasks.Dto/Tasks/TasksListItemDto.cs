using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTasks.Dto.Tasks
{
    [Serializable]
    public class TasksListItemDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long? EmployeeUserId { get; set; }

        public long ProjectId { get; set; }
    }
}
