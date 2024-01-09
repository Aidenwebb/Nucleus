using Nucleus.Application.Contacts.Commands.CreateContact;

namespace Nucleus.Web.Endpoints.Contact;

public class Contacts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateContact);
            // .MapGet(GetContactById, "{id}")
            // .MapGet(GetContactsWithPagination)
            // .MapPut(UpdateContact, "{id}")
            // .MapPut(UpdateContactDetail, "UpdateDetail/{id}")
            // .MapDelete(DeleteContact, "{id}");
    }
    
    public async Task<int> CreateContact(ISender sender, CreateContactCommand command)
    {
        return await sender.Send(command);
    }
    
}
