using System;
using System.Data.Entity;

namespace FamilyTasks.EfDao
{
    public class EfContext : DbContext
    {
        public EfContext()
           : base("name=familytasks_dbEntities")
        {

        }
        public virtual DbSet<User> Users { get; set; }
    }
}
