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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasRequired(a => a.User).WithRequiredDependent(b => b.Profile);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
    }
}
