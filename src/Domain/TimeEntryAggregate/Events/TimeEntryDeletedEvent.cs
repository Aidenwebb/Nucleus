using Nucleus.Domain.TimeEntryAggregate.Entities;

namespace Nucleus.Domain.TimeEntryAggregate.Events;

public class TimeEntryDeletedEvent : BaseEvent
{
    public TimeEntry TimeEntry { get; }

    public TimeEntryDeletedEvent(TimeEntry timeEntry)
    {
        TimeEntry = timeEntry;
    }
}
