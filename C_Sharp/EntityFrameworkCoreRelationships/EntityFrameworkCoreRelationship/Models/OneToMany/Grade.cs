using EntityFrameworkCoreRelationship.Models.OneToOne;

namespace EntityFrameworkCoreRelationship.Models.OneToMany
{
    public class Grade
    {
        public int GradeID { get; set; }

        public string GradeName { get; set; } = string.Empty;

        public string Section { get; set; } = string.Empty;

        #region One To Many Relationship - Convention Three
        /// <summary>
        /// This is Convention Three for ONE to Many Relationship
        /// To use C3 - Add navigational property from Parent (Here Student.cs)
        /// Reference Of multiple Students becomes Navigational property for Student
        /// It means - Multiple Students can hold the same Grade
        /// Once migration is done, it will create a foreign key in the Student table for Grade with GradeID
        /// Which means Multiple Student will same Grade OR One Grade can be assigned to multiple students
        /// </summary>
        public ICollection<Student> Students { get; set; } 
        #endregion
    }
}
