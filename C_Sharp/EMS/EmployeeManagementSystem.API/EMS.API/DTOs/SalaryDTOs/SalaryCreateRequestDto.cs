using System.ComponentModel.DataAnnotations;

namespace EMS.API.DTOs.SalaryDTOs
{
    public class SalaryCreateRequestDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }
    }
}
