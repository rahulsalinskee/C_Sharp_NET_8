using EntityFrameworkCoreRelationship.Models.ManyToMany;
using EntityFrameworkCoreRelationship.Models.OneToMany;
using EntityFrameworkCoreRelationship.Models.OneToOne;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreRelationship.DataContext
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentAddress> StudentAddresses { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasMany(student => student.Courses).WithMany(course => course.Students).UsingEntity(join => join.ToTable("StudentCourses"));

            modelBuilder.Entity<StudentCourse>().HasKey(studentCourse => new { studentCourse.StudentID, studentCourse.CourseID });
        }
    }
}
