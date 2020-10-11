using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Movie.Models
{
    public class MovieDbContext: IdentityDbContext<User>    
    {
        public DbSet<Film> Films { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Films)
                .WithOne(f => f.Author);

            modelBuilder.Entity<Film>()
                .HasOne(f => f.Author)
                .WithMany(u => u.Films);

            base.OnModelCreating(modelBuilder);
        }
    }
}
