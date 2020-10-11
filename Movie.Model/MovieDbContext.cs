using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Movie.Models
{
    public class MovieDbContext: IdentityDbContext<User>    
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Movies)
                .WithOne(f => f.Author);

            modelBuilder.Entity<Movie>()
                .HasOne(f => f.Author)
                .WithMany(u => u.Movies);

            base.OnModelCreating(modelBuilder);
        }
    }
}
