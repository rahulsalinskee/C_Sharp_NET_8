namespace EntityFrameworkCoreRelationship.Models.OneToOne
{
    public class StudentAddress
    {
        public int StudentAddressID { get; set; }

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public int StudentID { get; set; }

        #region One To One Relationship
        /// <summary>
        /// Reference Of Student becomes Navigational property for Student
        /// It means - Student Address can hold the student
        /// </summary>
        public Student Student { get; set; } 
        #endregion
    }
}
