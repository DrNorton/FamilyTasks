using System;

namespace FamilyTasks.Dto.Projects
{
    [Serializable]
    public class ProjectsListItemDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ProjectUrl { get; set; }
    }
}
