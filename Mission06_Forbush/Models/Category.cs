// Author: Adam Forbush
// Description: Movie Website for Joel Hilton

using System.ComponentModel.DataAnnotations;

namespace Mission06_Forbush.Models
{
    // Application class representing a movie application form model with attributes and validation rules for a database.
    public class Category
    {
        // Primary Key
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
