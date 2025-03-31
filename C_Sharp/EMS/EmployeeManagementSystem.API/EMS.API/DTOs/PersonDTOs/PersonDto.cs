using EMS.API.DTOs.PersonDetailDTOs;
using EMS.API.Models;
using System.ComponentModel.DataAnnotations;

namespace EMS.API.DTOs.PersonDTOs
{
    public class PersonDto
    {
        public int ID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Email { get; set; } = string.Empty;

        public string? Address { get; set; }

        public int PositionID { get; set; }

        public int SalaryID { get; set; }

        public PersonDetailDto? PersonDetail { get; set; }
    }
}
