using Assel.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assel.Data
{
    internal sealed class AsselDbContext(DbContextOptions<AsselDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Fact> Facts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("assel");
        }
    }
}
