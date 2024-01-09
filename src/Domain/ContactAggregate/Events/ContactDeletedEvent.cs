using Nucleus.Domain.ContactAggregate.Entities;

namespace Nucleus.Domain.ContactAggregate.Events;

public class ContactDeletedEvent : BaseEvent
{
    public ContactDeletedEvent(Contact contact)
    {
        Contact = contact;
    }

    public Contact Contact { get; }
}
