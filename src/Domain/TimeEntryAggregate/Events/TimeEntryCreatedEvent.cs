using Nucleus.Domain.TimeEntryAggregate.Entities;

namespace Nucleus.Domain.TimeEntryAggregate.Events;

public class TimeEntryCreatedEvent : BaseEvent
{
    public TimeEntry TimeEntry { get; }

    public TimeEntryCreatedEvent(TimeEntry timeEntry)
    {
        TimeEntry = timeEntry;
    }
}
