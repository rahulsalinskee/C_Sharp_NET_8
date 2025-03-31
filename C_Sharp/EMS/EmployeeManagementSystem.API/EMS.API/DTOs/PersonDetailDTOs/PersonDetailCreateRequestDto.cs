using System.ComponentModel.DataAnnotations;

namespace EMS.API.DTOs.PersonDetailDTOs
{
    public class PersonDetailCreateRequestDto
    {
        [Required]
        [StringLength(100)]
        public string PersonCity { get; set; } = string.Empty;

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public int PersonID { get; set; }
    }
}
