using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryID")]
    public int? CategoryID { get; set; }
    public Category? Category { get; set; } //public instance of the category
    
    [Required(ErrorMessage = "Please enter a movie title.")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Please enter a year.")]
    [Range(1888,2030)]
    public int Year { get; set; }
    
    public string? Rating { get; set; }
    
    public string? Director { get; set; }
    
    [Required(ErrorMessage = "Please Select if the movie was edited.")]
    public bool? Edited { get; set; }
    public string? LentTo { get; set; }
    public string? Notes { get; set; }
    
    [Required(ErrorMessage = "Please answer Copied to Plex filed.")]
    public bool? CopiedToPlex  { get; set; }
}

