using System.ComponentModel.DataAnnotations;

namespace EMS.API.DTOs.PositionDTOs
{
    public class PositionUpdateRequestDto
    {
        [StringLength(100, MinimumLength = 2)]
        public string? Name { get; set; }

        public int? DepartmentId { get; set; }
    }
}
