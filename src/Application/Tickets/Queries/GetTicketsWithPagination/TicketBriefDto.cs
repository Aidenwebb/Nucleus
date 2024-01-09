using Nucleus.Application.Companies.Queries.GetCompaniesWithPagination;
using Nucleus.Domain.CompanyAggregate.Entities;
using Nucleus.Domain.TicketAggregate.Entities;
using Nucleus.Domain.TicketAggregate.Enums;

namespace Nucleus.Application.Tickets.Queries.GetTicketsWithPagination;

public class TicketBriefDto
{
    public int Id { get; init; }
    public string? Summary { get; init; }
    public int? CompanyId { get; init; }
    public int? ContactId { get; init; }
    public TicketUrgency Urgency { get; init; }
    public TicketImpact Impact { get; init; }
    public int Priority { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Ticket, TicketBriefDto>();
        }
    }
}
