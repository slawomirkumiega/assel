using Assel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assel.Data
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.Facts);
            builder.Property(x => x.Id).IsRequired().HasMaxLength(100);
            builder.HasKey(x => x.Id);
        }
    }
}
