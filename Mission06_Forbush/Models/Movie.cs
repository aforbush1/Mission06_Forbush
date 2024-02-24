// Author: Adam Forbush
// Description: Movie Website for Joel Hilton

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Forbush.Models
{
    // Application class representing a movie application form model with attributes and validation rules for a database.
    public class Movie
    {
        // Primary Key
        [Key]
        [Required]
        public int MovieId { get; set; }
        // Foreign key that will be used to link category to movie
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required (ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
        [Required (ErrorMessage = "Please enter a year")]
        [Range(1888, int.MaxValue, ErrorMessage = "The year must be greater than or equal to 1888.")]
        public int? Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required (ErrorMessage = "Please enter if the movie was edited")]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [Required (ErrorMessage = "Please enter if the movie has been copied to plex.")]
        public bool CopiedToPlex { get; set; }
        // String indicating that you can't go past 25 characters
        [StringLength(25, ErrorMessage = "The Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}
