using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Kehl.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [ForeignKey("Category")]
        [Required] // Category is now required
        public int? CategoryId { get; set; }
        public Category? Category { get; set; } 

        [Required]
        public required string Title { get; set; }

        [Required]
        [Range(1888, 2100, ErrorMessage = "Please enter a valid year.")]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }

        [Required] //
        public bool CopiedToPlex { get; set; }

        public string? LentTo { get; set; }

        [MaxLength(25, ErrorMessage = "Notes must be 25 characters or fewer.")]
        public string? Notes { get; set; }
    }
}
