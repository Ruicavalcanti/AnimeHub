using AnimeHub.Domain.Entities;
using AnimeHub.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
namespace AnimeHub.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Anime> Animes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AnimeConfiguration());

        }
    }
}
