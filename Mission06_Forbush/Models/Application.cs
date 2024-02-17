// Author: Adam Forbush
// Description: Movie Website for Joel Hilton

using System.ComponentModel.DataAnnotations;

namespace Mission06_Forbush.Models
{
    // Application class representing a movie application form model with attributes and validation rules for a database.
    public class Application
    {
        // Primary Key
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        // String indicating that you can't go past 25 characters
        [StringLength(25, ErrorMessage = "The Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}
