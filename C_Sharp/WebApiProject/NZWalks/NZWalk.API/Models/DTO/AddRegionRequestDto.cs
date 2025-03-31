using System.ComponentModel.DataAnnotations;

namespace NZWalk.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be of minimum 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has to be of maximum 3 characters")]
        public string Code { get; set; } = string.Empty;

        [Required]
        [MaxLength(100, ErrorMessage = "Code has to be of maximum 100 characters")]
        public string Name { get; set; } = string.Empty;

        public string? RegionImageUrl { get; set; }
    }
}
