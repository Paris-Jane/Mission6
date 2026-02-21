using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models;

public class Movie
{
    [Key] [Required]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryID")] [Required]
    public int CategoryID { get; set; }
    public Category Category { get; set; } //public instance of the category
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public int Year { get; set; }
    
    public string? Rating { get; set; }
    
    public string? Director { get; set; }
    public bool? Edited { get; set; }
    public string? LentTo { get; set; }
    public string? Notes { get; set; }
    
    public bool? CopiedToPlex  { get; set; }
}

