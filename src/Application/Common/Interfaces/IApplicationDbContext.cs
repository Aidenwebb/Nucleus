using Nucleus.Domain.CompanyAggregate.Entities;
using Nucleus.Domain.ContactAggregate.Entities;
using Nucleus.Domain.Entities;

namespace Nucleus.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    
    DbSet<Company>  Companies { get; }
    DbSet<Contact>  Contacts { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
