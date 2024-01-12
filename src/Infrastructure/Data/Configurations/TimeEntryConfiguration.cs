using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.Domain.TimeEntryAggregate.Entities;

namespace Nucleus.Infrastructure.Data.Configurations;

public class TimeEntryConfiguration : IEntityTypeConfiguration<TimeEntry>
{
    public void Configure(EntityTypeBuilder<TimeEntry> builder)
    {
        builder.Property(timeEntry => timeEntry.CompanyId)
            .IsRequired();

        builder.Property(timeEntry => timeEntry.TimeStart)
            .HasDefaultValue(DateTime.UtcNow)
            .IsRequired();
    }
}
