using EMS.API.DTOs.PersonDetailDTOs;
using System.ComponentModel.DataAnnotations;

namespace EMS.API.DTOs.PersonDTOs
{
    public class PersonCreateRequestDto
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public string? Address { get; set; }

        [Required]
        public int PositionID { get; set; }

        [Required]
        public int SalaryID { get; set; }

        public PersonDetailCreateRequestDto? PersonDetail { get; set; }
    }
}
