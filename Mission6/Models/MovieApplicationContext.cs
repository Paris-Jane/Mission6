using Microsoft.EntityFrameworkCore;

namespace Mission6.Models;

public class MovieApplicationContext : DbContext // Inherit from the DB CONTEXT
{
    public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options)
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    

}