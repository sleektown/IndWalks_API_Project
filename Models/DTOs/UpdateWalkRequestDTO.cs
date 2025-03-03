using System.ComponentModel.DataAnnotations;

namespace INDWalks.Models.DTOs
{
    public class UpdateWalkRequestDTO
    {
        [Required]
        [MinLength(5, ErrorMessage = "Min name length is 5")]
        public string Name { get; set; }

        [Required]
        [MinLength(30, ErrorMessage = "Min description length is 30")]
        [MaxLength(500, ErrorMessage = "Max description length is 500")]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        public double? LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }

        [Required]
        public Guid RegionId { get; set; }
    }
}
