using Nucleus.Domain.CompanyAggregate.Entities;
using Nucleus.Domain.ContactAggregate.Entities;
using Nucleus.Domain.TicketAggregate.Enums;

namespace Nucleus.Domain.TicketAggregate.Entities;

public class Ticket : BaseAuditableEntity
{
    public string? Summary { get; set; }
    public string? Description { get; set; }
    
    public string? ExpectedResult { get; set; } // What is the desired or expected outcome of the ticket?
    
    public string? ExternalReference { get; set; }

    public int? CompanyId { get; set; }
    public Company? Company { get; set; } = null!;
    
    public int? ContactId { get; set; }
    public Contact? Contact { get; set; } = null!;

    public TicketUrgency? Urgency { get; set; } = TicketUrgency.Medium;
    public TicketImpact? Impact { get; set; } = TicketImpact.Medium;

    public int Priority { get; set; }
}
