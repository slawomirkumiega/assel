using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using users.Entities;

namespace users.Data
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Login).IsRequired().HasMaxLength(100);
        }
    }
}
