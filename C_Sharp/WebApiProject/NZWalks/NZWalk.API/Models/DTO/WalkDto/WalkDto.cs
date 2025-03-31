using NZWalk.API.Models.DTO.DifficultyDtos;

namespace NZWalk.API.Models.DTO.WalkDto
{
    public class WalkDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double LengthInKiloMeter { get; set; }

        public string? ImageUrl { get; set; }

        /* Navigation Property - Walk can always have a region */
        public RegionDto RegionDto { get; set; }

        /* Navigation Property - Walk can have difficulty OR walk can be difficult */
        public DifficultyDto DifficultyDto { get; set; }
    }
}
