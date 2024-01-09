using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.Domain.CompanyAggregate.Entities;

namespace Nucleus.Infrastructure.Data.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.Property(company => company.Identifier)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(company => company.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}
