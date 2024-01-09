using Nucleus.Domain.ContactAggregate.Entities;

namespace Nucleus.Application.Contacts.Queries.GetContactsWithPagination;

public class ContactBriefDto
{
    
    public int Id { get; init; }
    public int CompanyId { get; init; }
    
    public string? GivenName { get; init; }
    public string? FamilyName { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Contact, ContactBriefDto>();
        }
    }
    
}
