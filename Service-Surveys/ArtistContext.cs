using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;

using Surveys.Models;

namespace Surveys.Data
{
    public class ArtistContext : DbContext
    {
        public ArtistContext(DbContextOptions<ArtistContext> opt) : base(opt)
        {
            
        }

        public DbSet<ArtistOfTheWeek> ArtistsOfTheWeek { get; set; }
        
    }
}