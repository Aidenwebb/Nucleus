using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.TicketAggregate.Events;

namespace Nucleus.Application.Tickets.Commands.DeleteTicket;

public record DeleteTicketCommand(int Id) : IRequest;

public class DeleteTicketCommandValidator : AbstractValidator<DeleteTicketCommand>
{
    public DeleteTicketCommandValidator()
    {
    }
}

public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tickets
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Tickets.Remove(entity);
        
        entity.AddDomainEvent(new TicketDeletedEvent(entity));
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}
