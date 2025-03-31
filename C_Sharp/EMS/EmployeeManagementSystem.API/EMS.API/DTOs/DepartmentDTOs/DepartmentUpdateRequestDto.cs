using System.ComponentModel.DataAnnotations;

namespace EMS.API.DTOs.DepartmentDTOs
{
    public class DepartmentUpdateRequestDto
    {
        [StringLength(100, MinimumLength = 2)]
        public string? Name { get; set; }
    }
}
