using Nucleus.Domain.CompanyAggregate.Entities;

namespace Nucleus.Domain.ContactAggregate.Entities;

public class Contact : BaseAuditableEntity
{
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public string? GivenName { get; set; }
    public string? FamilyName { get; set; }

    public int? ManagerContactId { get; set; }
    public Contact? ManagerContact { get; set; } = null!;

    public int? AssistantContactId { get; set; }
    public Contact? AssistantContact { get; set; } = null!;
}
