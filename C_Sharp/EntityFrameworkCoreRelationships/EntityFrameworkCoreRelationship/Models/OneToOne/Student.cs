using EntityFrameworkCoreRelationship.Models.ManyToMany;
using EntityFrameworkCoreRelationship.Models.OneToMany;

namespace EntityFrameworkCoreRelationship.Models.OneToOne
{
    public class Student
    {
        public int ID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        #region One To One Relationship
        /// <summary>
        /// Reference Of Student Address becomes Navigational property for StudentAddress
        /// It means - Student can hold the student address
        /// </summary>
        public StudentAddress? StudentAddress { get; set; }
        #endregion

        #region One To Many Relationship - Convention Three
        /// <summary>
        /// To use Convention Three to Many Relationship - Add this navigational property AND add a collection of students in Grade.cs
        /// Reference Of Grade becomes Navigational property for Grade
        /// It means - Student can hold the Grade
        /// Once migration is done, it will create a foreign key in the Student table for Grade with GradeID
        /// Which means Multiple Student will same Grade OR One Grade can be assigned to multiple students
        /// </summary>
        public Grade Grade { get; set; }
        #endregion

        #region Many To Many Relationship
        /// <summary>
        /// This means - Multiple Courses can be enrolled for a student
        /// </summary>
        public IList<Course> Courses { get; set; }
        #endregion
    }
}
