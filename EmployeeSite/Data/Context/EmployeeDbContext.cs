namespace EmployeeSite.Data.Context
{
    using EmployeeSite.Data.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("name=EmployeeDbContext")
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeActivity> EmployeeActivities { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionTie> PermissionsTie { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .Property(c => c.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Employee>().HasKey(x => x.Id);
            modelBuilder.Entity<Employee>()
                        .Property(c => c.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Employee>().HasKey(x => x.Id);
            modelBuilder.Entity<Department>().HasKey(x => x.Id);
            modelBuilder.Entity<Permission>().HasKey(x => x.Id);
            modelBuilder.Entity<PermissionTie>().Property(x => x.EmployeeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<PermissionTie>().Property(x => x.PermissionId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}