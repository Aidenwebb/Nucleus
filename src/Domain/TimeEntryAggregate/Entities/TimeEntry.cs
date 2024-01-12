using Nucleus.Domain.CompanyAggregate.Entities;
using Nucleus.Domain.TicketAggregate.Entities;
using Nucleus.Domain.TimeEntryAggregate.Enums;

namespace Nucleus.Domain.TimeEntryAggregate.Entities;

public class TimeEntry : BaseAuditableEntity
{
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    
    public int? ChargeToCompanyId { get; set; }
    public Company? ChargeToCompany { get; set; }

    public ChargeToType? ChargeToType { get; set; }

    public DateTime TimeStart { get; set; }

    public DateTime? TimeEnd { get; set; }

    public string? EnteredBy { get; set; }
    
    public string? PublicNotes { get; set; }
    public string? InternalNotes { get; set; }
    public string? PrivateNotes { get; set; }

    public int? TicketId { get; set; }
    public Ticket? Ticket { get; set; }
}
