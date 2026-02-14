using System.ComponentModel.DataAnnotations;

namespace Mission6.Models;

public class Application
{
    [Key] [Required]
    public int MovieId { get; set; }
    
    [Required]
    public string Category { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public int Year { get; set; }
    
    [Required]
    public string Rating { get; set; }
    
    [Required]
    public string Director { get; set; }
    public bool Edited { get; set; }
    public string Lent { get; set; }
    public string Notes { get; set; }
}

