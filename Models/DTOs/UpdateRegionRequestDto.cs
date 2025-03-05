using System.ComponentModel.DataAnnotations;

namespace INDWalks.Models.DTOs
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Min length of code field is 2.")]
        [MaxLength(10, ErrorMessage = "Max length of code field is 10.")]
        public string Code { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Min length of name field is 5.")]
        [MaxLength(50, ErrorMessage = "Max length of name field is 20.")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
