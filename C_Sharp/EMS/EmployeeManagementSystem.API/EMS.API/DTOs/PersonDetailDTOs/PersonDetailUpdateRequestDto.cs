using System.ComponentModel.DataAnnotations;

namespace EMS.API.DTOs.PersonDetailDTOs
{
    public class PersonDetailUpdateRequestDto
    {
        [StringLength(100)]
        public string? PersonCity { get; set; }

        public DateTime? Birthday { get; set; }
    }
}
