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
    
    public partial class TasksAttachedFile
    {
        public long Id { get; set; }
        public long AttachedFileId { get; set; }
        public long TaskId { get; set; }
    
        public virtual AttachedFile AttachedFile { get; set; }
        public virtual Task Task { get; set; }
    }
}
