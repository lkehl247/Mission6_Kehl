using System.ComponentModel.DataAnnotations;

namespace Mission6_Kehl.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1888, 2100, ErrorMessage = "Please enter a valid year.")]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public bool Edited { get; set; } // No nullable type, forcing a selection

        public string? LentTo { get; set; } // Optional

        [MaxLength(25, ErrorMessage = "Notes must be 25 characters or fewer.")]
        public string? Notes { get; set; } // Optional with length constraint
    }

}
