using Microsoft.EntityFrameworkCore;

namespace Mission6_Nieves.Models
{
    public class SubmitFilmContext : DbContext
    {
        public SubmitFilmContext(DbContextOptions<SubmitFilmContext> options) : base (options)
        { 
        }

        public DbSet<FilmSubmission> FilmCollection { get; set; }
    }
}
