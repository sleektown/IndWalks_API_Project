using System.ComponentModel.DataAnnotations;

namespace INDWalks.Models.DTOs
{
    public class UpdateWalkRequestDTO
    {
        [Required]
<<<<<<< HEAD
        [MinLength(5, ErrorMessage = "Min length of name field is 5.")]
        [MaxLength(50, ErrorMessage = "Max length of name field is 50.")]
        public string Name { get; set; }

        [Required]
        [MinLength(30, ErrorMessage = "Min length of description field is 30.")]
        [MaxLength(5000, ErrorMessage = "Max length of description field is 5000.")]
        public string Description { get; set; }

        [Required]
        [Range(0.1, 100, ErrorMessage = "Length in km must be between 0.1 Km and 100 Km.")]
        public double LengthInKm { get; set; }
=======
        [MinLength(5, ErrorMessage = "Min name length is 5")]
        public string Name { get; set; }

        [Required]
        [MinLength(30, ErrorMessage = "Min description length is 30")]
        [MaxLength(500, ErrorMessage = "Max description length is 500")]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        public double? LengthInKm { get; set; }
>>>>>>> b7c2fdf96445235eec9decdc0f44e996b4ba6c4e

        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }

        [Required]
        public Guid RegionId { get; set; }
    }
}
