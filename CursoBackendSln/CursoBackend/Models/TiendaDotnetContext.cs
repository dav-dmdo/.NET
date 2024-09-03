using Microsoft.EntityFrameworkCore;

namespace CursoBackend.Models
{
    public class TiendaDotnetContext : DbContext
    {
        public TiendaDotnetContext(DbContextOptions<TiendaDotnetContext> options)
            : base(options)
        {
            
        }

        public DbSet<Beer> Beers {get;set;}
        public DbSet<Brand> Brands {get;set;}
    }
}