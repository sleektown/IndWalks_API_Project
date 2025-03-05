using System.ComponentModel.DataAnnotations;

namespace INDWalks.Models.DTOs
{
    public class UpdateRegionRequestDto
    {
        [Required]
<<<<<<< HEAD
        [MinLength(2, ErrorMessage = "Min length of code field is 2.")]
        [MaxLength(10, ErrorMessage = "Max length of code field is 10.")]
        public string Code { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Min length of name field is 5.")]
        [MaxLength(50, ErrorMessage = "Max length of name field is 20.")]
=======
        [MinLength(2, ErrorMessage = "Min code length is 2")]
        [MaxLength(10, ErrorMessage = "Max code length is 10")]
        public string Code { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Min name length is 5")]
        [MaxLength(50, ErrorMessage = "Max name length is 50")]
>>>>>>> b7c2fdf96445235eec9decdc0f44e996b4ba6c4e
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
