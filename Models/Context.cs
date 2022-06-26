using Microsoft.EntityFrameworkCore;

namespace Day2.Models
{
    public class Context:DbContext
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Trainee> Trainees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ITIMVCCore;Integrated Security=True");
        }
    }
}
