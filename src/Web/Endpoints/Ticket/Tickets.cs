using Nucleus.Application.Tickets.Commands.CreateTicket;

namespace Nucleus.Web.Endpoints.Ticket;

public class Tickets : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateTicket);
        // .MapGet(GetTicketById, "{id}")
        // .MapGet(GetTicketsWithPagination)
        // .MapPut(UpdateTicket, "{id}")
        // .MapPut(UpdateTicketDetail, "UpdateDetail/{id}")
        // .MapDelete(DeleteTicket, "{id}");
    }
    
    public async Task<int> CreateTicket(ISender sender, CreateTicketCommand command)
    {
        return await sender.Send(command);
    }
    
}
