using Nucleus.Application.Common.Models;
using Nucleus.Application.Contacts.Commands.CreateContact;
using Nucleus.Application.Contacts.Commands.DeleteContact;
using Nucleus.Application.Contacts.Commands.UpdateContact;
using Nucleus.Application.Contacts.Queries.GetContact;
using Nucleus.Application.Contacts.Queries.GetContactsWithPagination;

namespace Nucleus.Web.Endpoints.Contact;

public class Contacts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateContact)
            .MapGet(GetContactById, "{id}")
            .MapGet(GetContactsWithPagination)
            .MapPut(UpdateContact, "{id}")
            // .MapPut(UpdateContactDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteContact, "{id}");
    }
    
    public async Task<int> CreateContact(ISender sender, CreateContactCommand command)
    {
        return await sender.Send(command);
    }
    
    public async Task<ContactDetailDto> GetContactById(ISender sender, [AsParameters] GetContactQuery query)
    {
        return await sender.Send(query);
    }
    
    public async Task<PaginatedList<ContactBriefDto>> GetContactsWithPagination(ISender sender, [AsParameters] GetContactsWithPaginationQuery query)
    {
        return await sender.Send(query);
    }
    
    public async Task<IResult> UpdateContact(ISender sender, int id, UpdateContactCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
    
    public async Task<IResult> DeleteContact(ISender sender, int id)
    {
        await sender.Send(new DeleteContactCommand(id));
        return Results.NoContent();
    }
    
    
}
