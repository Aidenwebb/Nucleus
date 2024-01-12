using Nucleus.Domain.TicketAggregate.Entities;

namespace Nucleus.Domain.TicketAggregate.Events;

public class TicketDeletedEvent : BaseEvent
{
    public Ticket Ticket { get; }

    public TicketDeletedEvent(Ticket ticket)
    {
        Ticket = ticket;
    }
}
