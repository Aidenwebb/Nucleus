using Nucleus.Domain.CompanyAggregate.Entities;
using Nucleus.Domain.ContactAggregate.Entities;
using Nucleus.Domain.Entities;
using Nucleus.Domain.TicketAggregate.Entities;
using Nucleus.Domain.TimeEntryAggregate.Entities;

namespace Nucleus.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    
    DbSet<Company>  Companies { get; }
    DbSet<Contact>  Contacts { get; }
    
    DbSet<Ticket>  Tickets { get; }
    
    DbSet<TimeEntry> TimeEntries { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
