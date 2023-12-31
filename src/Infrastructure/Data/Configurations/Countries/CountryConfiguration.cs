using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.Domain.Entities.Countries;

namespace Nucleus.Infrastructure.Data.Configurations.Countries;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(entity => entity.Identifier)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(entity => entity.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(entity => entity.CountryCode)
            .HasMaxLength(2)
            .IsRequired();
    }
}
