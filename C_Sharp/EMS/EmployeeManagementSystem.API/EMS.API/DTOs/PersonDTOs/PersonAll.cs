namespace EMS.API.DTOs.PersonDTOs
{
    public class PersonAll
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string PositionName { get; set; } = string.Empty;

        public string DepartmentName { get; set; } = string.Empty;

        public int Salary { get; set; }

        public string PersonCity { get; set; } = string.Empty;
    }
}
