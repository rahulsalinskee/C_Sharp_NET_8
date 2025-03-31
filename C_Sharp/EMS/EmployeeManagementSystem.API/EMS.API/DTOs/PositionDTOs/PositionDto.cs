using System.ComponentModel.DataAnnotations;

namespace EMS.API.DTOs.PositionDTOs
{
    public class PositionDto
    {
        public int PositionID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
    }
}
