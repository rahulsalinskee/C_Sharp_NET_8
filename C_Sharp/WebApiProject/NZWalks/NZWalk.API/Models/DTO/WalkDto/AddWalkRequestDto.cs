using System.ComponentModel.DataAnnotations;

namespace NZWalk.API.Models.DTO.WalkDto
{
    public class AddWalkRequestDto
    {
        [Required]
        [MinLength(100, ErrorMessage = "Minimum Length is 100")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000, ErrorMessage = "Maximum Length is 1000")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0, 50)]
        public double LengthInKiloMeter { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }

        [Required]
        public Guid RegionId { get; set; }
    }
}
