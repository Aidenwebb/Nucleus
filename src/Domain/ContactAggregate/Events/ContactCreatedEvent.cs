using Nucleus.Domain.ContactAggregate.Entities;

namespace Nucleus.Domain.ContactAggregate.Events;

public class ContactCreatedEvent : BaseEvent
{
    public ContactCreatedEvent(Contact contact)
    {
        Contact = contact;
    }

    public Contact Contact { get; }
}
