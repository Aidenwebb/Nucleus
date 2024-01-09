using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.TicketAggregate.Entities;
using Nucleus.Domain.TicketAggregate.Enums;
using Nucleus.Domain.TicketAggregate.Events;

namespace Nucleus.Application.Tickets.Commands.CreateTicket;

public record CreateTicketCommand : IRequest<int>
{
    public string? Summary { get; init; }

    public int? CompanyId { get; init; }

    public int? ContactId { get; init; }

    public TicketUrgency? Urgency { get; init; }

    public TicketImpact? Impact { get; init; }
    
}

public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidator()
    {
        RuleFor(v => v.Summary)
            .MaximumLength(200)
            .NotEmpty();
    }
}

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var entity = new Ticket
        {
            Summary = request.Summary,
            CompanyId = request.CompanyId,
            ContactId = request.ContactId,
            Urgency = request.Urgency,
            Impact = request.Impact
        };
        
        entity.AddDomainEvent(new TicketCreatedEvent(entity));

        _context.Tickets.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;

    }
}
