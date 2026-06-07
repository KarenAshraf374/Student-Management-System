using Microsoft.EntityFrameworkCore;
using Student_Management_System.Modules;

namespace Student_Management_System.Database
{
    public class SchoolSystemDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.; Database=StudentManagementSystemDB; Trusted_Connection = True; TrustServerCertificate = True");
        }
    }
}
