using EducationCenter.Domain.Entities.Courses;
using EducationCenter.Domain.Entities.Departments;
using EducationCenter.Domain.Entities.Groups;
using EducationCenter.Domain.Entities.Students;
using EducationCenter.Domain.Entities.Teachers;
using Microsoft.EntityFrameworkCore;

namespace EducationCenter.Data.Contexts
{
    public class EducationCenterDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=EduCenterDb;Username=postgres;Password=2003");
        }

    }
}
