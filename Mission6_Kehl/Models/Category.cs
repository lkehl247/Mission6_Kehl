using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace Mission6_Kehl.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public required string CategoryName { get; set; }

        // ✅ Navigation property for Movies
        public List<Movie>? Movies { get; set; }
    }
}

