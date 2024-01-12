using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.TicketAggregate.Enums;

namespace Nucleus.Application.Tickets.Commands.UpdateTicket;

public record UpdateTicketCommand : IRequest
{
    public int Id { get; init; }
    public string? Summary { get; init; }
    public string? Description { get; init; }
    public int? CompanydId { get; init; }
    public int? ContactId { get; init; }
    public TicketUrgency? Urgency { get; init; }
    public TicketImpact? Impact { get; init; }
}

public class UpdateTicketCommandValidator : AbstractValidator<UpdateTicketCommand>
{
    public UpdateTicketCommandValidator()
    {
        RuleFor(v => v.Summary)
            .MaximumLength(200)
            .NotEmpty();
    }
}

public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tickets
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Summary = request.Summary;
        entity.Description = request.Description;
        entity.CompanyId = request.CompanydId;
        entity.ContactId = request.ContactId;
        entity.Urgency = request.Urgency;
        entity.Impact = request.Impact;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
