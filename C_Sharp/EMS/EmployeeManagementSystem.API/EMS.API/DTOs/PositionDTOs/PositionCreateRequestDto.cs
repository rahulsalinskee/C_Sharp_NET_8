using System.ComponentModel.DataAnnotations;

namespace EMS.API.DTOs.PositionDTOs
{
    public class PositionCreateRequestDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int DepartmentId { get; set; }
    }
}
