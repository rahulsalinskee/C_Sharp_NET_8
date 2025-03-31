using EMS.API.DTOs.PersonDetailDTOs;
using System.ComponentModel.DataAnnotations;

namespace EMS.API.DTOs.PersonDTOs
{
    public class PersonUpdateRequestDto
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string? Address { get; set; }

        public int PositionID { get; set; }

        public int SalaryID { get; set; }

        public PersonDetailUpdateRequestDto? PersonDetail { get; set; }
    }
}
