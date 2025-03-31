namespace NZWalk.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double LengthInKiloMeter { get; set; }

        public string? ImageUrl { get; set; }

        /* Creating Connection or Relationship between Domain Models */
        /* Walk can be Difficult - Easy, Medium, Hard */
        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }

        /* Navigation Property - Walk can have difficulty OR walk can be difficult */
        public Difficulty Difficulty { get; set; }

        /* Navigation Property - Walk can always have a region */
        public Region Region { get; set; }
    }
}
