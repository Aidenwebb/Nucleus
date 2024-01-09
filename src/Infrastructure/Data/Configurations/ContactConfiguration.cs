using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.Domain.ContactAggregate.Entities;

namespace Nucleus.Infrastructure.Data.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.Property(contact => contact.GivenName)
            .HasMaxLength(200);

        builder.Property(contact => contact.FamilyName)
            .HasMaxLength(200);

        builder.HasOne(contact => contact.AssistantContact)
            .WithOne()
            .HasForeignKey<Contact>(contact => contact.AssistantContactId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(contact => contact.ManagerContact)
            .WithOne()
            .HasForeignKey<Contact>(contact => contact.ManagerContactId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
