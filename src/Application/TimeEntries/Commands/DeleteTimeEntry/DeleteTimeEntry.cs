using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.TimeEntryAggregate.Events;

namespace Nucleus.Application.TimeEntries.Commands.DeleteTimeEntry;

public record DeleteTimeEntryCommand(int Id) : IRequest;

public class DeleteTimeEntryCommandValidator : AbstractValidator<DeleteTimeEntryCommand>
{
    public DeleteTimeEntryCommandValidator()
    {
    }
}

public class DeleteTimeEntryCommandHandler : IRequestHandler<DeleteTimeEntryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTimeEntryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTimeEntryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TimeEntries
            .FindAsync(new object[] { request.Id },cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TimeEntries.Remove(entity);
        
        entity.AddDomainEvent(new TimeEntryDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);


    }
}
