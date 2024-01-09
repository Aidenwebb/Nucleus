using Nucleus.Domain.TicketAggregate.Entities;

namespace Nucleus.Domain.TicketAggregate.Events;

public class TicketCreatedEvent : BaseEvent
{
    public Ticket Ticket { get; }

    public TicketCreatedEvent(Ticket ticket)
    {
        Ticket = ticket;
    }
}
