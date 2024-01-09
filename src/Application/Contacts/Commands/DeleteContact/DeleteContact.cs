using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.ContactAggregate.Events;

namespace Nucleus.Application.Contacts.Commands.DeleteContact;

public record DeleteContactCommand(int Id) : IRequest;

public class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
{
    public DeleteContactCommandValidator()
    {
    }
}

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteContactCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Contacts
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Contacts.Remove(entity);
        
        entity.AddDomainEvent(new ContactDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
