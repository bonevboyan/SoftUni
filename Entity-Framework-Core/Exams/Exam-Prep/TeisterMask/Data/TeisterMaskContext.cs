namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;
    using TeisterMask.Data.Models;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() { }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmployeesTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTask>()
                .HasKey(et => new { et.TaskId, et.EmployeeId });

            modelBuilder.Entity<EmployeeTask>()
                .HasOne(sc => sc.Task)
                .WithMany(s => s.EmployeesTasks)
                .HasForeignKey(sc => sc.TaskId);

            modelBuilder.Entity<EmployeeTask>()
                .HasOne(sc => sc.Employee)
                .WithMany(s => s.EmployeesTasks)
                .HasForeignKey(sc => sc.EmployeeId);
        }
    }
}