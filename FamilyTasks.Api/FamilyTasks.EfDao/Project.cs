//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FamilyTasks.EfDao
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public Project()
        {
            this.ProjectAttachedFiles = new HashSet<ProjectAttachedFile>();
            this.ProjectMembers = new HashSet<ProjectMember>();
            this.Tasks = new HashSet<Task>();
        }
    
        public long Id { get; set; }
        public string Name { get; set; }
        public long CreatedUserId { get; set; }
        public string Description { get; set; }
        public string ProjectImageUrl { get; set; }
    
        public virtual ICollection<ProjectAttachedFile> ProjectAttachedFiles { get; set; }
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
