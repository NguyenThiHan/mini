namespace WebBasic.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ManagerDbContext : DbContext
    {
        public ManagerDbContext()
            : base("name=ManagerDbContext")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithMany(e => e.Departments)
                .Map(m => m.ToTable("Emp_Dep").MapLeftKey("IdDepartment").MapRightKey("IdEmployee"));

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.UserLogins)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.IdEmployeee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Salary)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Position)
                .WillCascadeOnDelete(false);
        }
    }
}
