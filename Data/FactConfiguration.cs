using Assel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assel.Data
{
    internal sealed class FactConfiguration : IEntityTypeConfiguration<Fact>
    {
        public void Configure(EntityTypeBuilder<Fact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.FactText).HasMaxLength(400);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.PetType).HasConversion<int>().IsRequired();
        }
    }
}
