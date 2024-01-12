using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.Domain.TicketAggregate.Entities;
using Nucleus.Domain.TicketAggregate.Enums;

namespace Nucleus.Infrastructure.Data.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(ticket => ticket.Summary)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(ticket => ticket.Description)
            .HasMaxLength(10000);

        builder.Property(ticket => ticket.Urgency)
            .HasDefaultValue(TicketUrgency.Medium);

        builder.Property(ticket => ticket.Impact)
            .HasDefaultValue(TicketImpact.Medium);

        builder.Property(ticket => ticket.Priority)
            .HasComputedColumnSql("[Impact] * [Urgency]", stored: true);
    }
}
