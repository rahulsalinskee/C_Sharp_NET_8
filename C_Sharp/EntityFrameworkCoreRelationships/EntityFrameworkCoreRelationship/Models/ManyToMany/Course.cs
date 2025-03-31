using EntityFrameworkCoreRelationship.Models.OneToOne;

namespace EntityFrameworkCoreRelationship.Models.ManyToMany
{
    public class Course
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// This means - Multiple Students can enroll for a Course
        /// </summary>
        public IList<Student> Students { get; set; }
    }
}
