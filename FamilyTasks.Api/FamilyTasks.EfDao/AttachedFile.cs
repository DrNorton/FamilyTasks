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
    
    public partial class AttachedFile
    {
        public AttachedFile()
        {
            this.ProjectAttachedFiles = new HashSet<ProjectAttachedFile>();
            this.TasksAttachedFiles = new HashSet<TasksAttachedFile>();
        }
    
        public long Id { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
    
        public virtual ICollection<ProjectAttachedFile> ProjectAttachedFiles { get; set; }
        public virtual ICollection<TasksAttachedFile> TasksAttachedFiles { get; set; }
    }
}
