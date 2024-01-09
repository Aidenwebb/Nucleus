using Nucleus.Domain.CompanyAggregate;
using Nucleus.Domain.Entities;

namespace Nucleus.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    
    DbSet<Company>  Companies { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
