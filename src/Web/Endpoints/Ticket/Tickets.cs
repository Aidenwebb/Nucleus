using Nucleus.Application.Common.Models;
using Nucleus.Application.Tickets.Commands.CreateTicket;
using Nucleus.Application.Tickets.Queries.GetTicket;
using Nucleus.Application.Tickets.Queries.GetTicketsWithPagination;

namespace Nucleus.Web.Endpoints.Ticket;

public class Tickets : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateTicket)
            .MapGet(GetTicketById, "{id}")
            .MapGet(GetTicketsWithPagination);
        // .MapPut(UpdateTicket, "{id}")
        // .MapPut(UpdateTicketDetail, "UpdateDetail/{id}")
        // .MapDelete(DeleteTicket, "{id}");
    }
    
    public async Task<int> CreateTicket(ISender sender, CreateTicketCommand command)
    {
        return await sender.Send(command);
    }
    
    public async Task<TicketDetailDto> GetTicketById(ISender sender, [AsParameters] GetTicketQuery query)
    {
        return await sender.Send(query);
    }
    
    public async Task<PaginatedList<TicketBriefDto>> GetTicketsWithPagination(ISender sender, [AsParameters] GetTicketsWithPaginationQuery query)
    {
        return await sender.Send(query);
    }
    
}
