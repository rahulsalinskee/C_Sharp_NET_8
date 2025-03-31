using System.ComponentModel.DataAnnotations;

namespace EMS.API.DTOs.DepartmentDTOs
{
    public class DepartmentDto
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
