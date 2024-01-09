using Nucleus.Domain.ContactAggregate.Entities;

namespace Nucleus.Application.Contacts.Queries.GetContact;

public class ContactDetailDto
{
    public int Id { get; init; }
    public int CompanyId { get; init; }
    
    public string? GivenName { get; init; }
    public string? FamilyName { get; init; }
    
    public int? ManagerContactId { get; init; }
    public int? AssistantContactId { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Contact, ContactDetailDto>();
        }
    }
}
