using Nucleus.Domain.TicketAggregate.Entities;
using Nucleus.Domain.TicketAggregate.Enums;

namespace Nucleus.Application.Tickets.Queries.GetTicket;

public class TicketDetailDto
{
    public int Id { get; set; }
    public string? Summary { get; set; }
    public string? ExpectedResult { get; set; }
    public string? Description { get; set; }
    public string? ExternalReference { get; set; }
    public int? CompanyId { get; set; }
    public int? ContactId { get; set; }
    public TicketUrgency Urgency { get; set; }
    public TicketImpact Impact { get; set; }
    public int Priority { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Ticket, TicketDetailDto>();
        }
    }
}
