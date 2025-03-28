﻿using System.ComponentModel.DataAnnotations;

namespace INDWalks.Models.DTOs
{
    public class AddRegionRequestDto
    {
        [Required]

        [MinLength(2, ErrorMessage = "Min length of code field is 2.")]
        [MaxLength(10, ErrorMessage = "Max length of code field is 10.")]
        public string Code { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Min name length is 5")]
        [MaxLength(50, ErrorMessage = "Max name length is 50")]

        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
