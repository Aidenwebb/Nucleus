using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.TimeEntryAggregate.Enums;

namespace Nucleus.Application.TimeEntries.Commands.UpdateTimeEntry;

public record UpdateTimeEntryCommand : IRequest
{
    public int Id { get; init; }
    public int CompanyId { get; init; }
    
    public int? ChargeToCompanyId { get; init; }

    public ChargeToType? ChargeToType { get; init; }

    public DateTime TimeStart { get; init; }

    public DateTime? TimeEnd { get; init; }
    
    public string? PublicNotes { get; init; }
    public string? InternalNotes { get; init; }
    public string? PrivateNotes { get; init; }

    public int? TicketId { get; init; }
}

public class UpdateTimeEntryCommandValidator : AbstractValidator<UpdateTimeEntryCommand>
{
    public UpdateTimeEntryCommandValidator()
    {
        RuleFor(v => v.CompanyId)
            .NotEmpty();
    }
}

public class UpdateTimeEntryCommandHandler : IRequestHandler<UpdateTimeEntryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTimeEntryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTimeEntryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TimeEntries
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.CompanyId = request.CompanyId;
        entity.ChargeToCompanyId = request.ChargeToCompanyId;
        entity.ChargeToType = request.ChargeToType;
        entity.TimeStart = request.TimeStart;
        entity.TimeEnd = request.TimeEnd;
        entity.PublicNotes = request.PublicNotes;
        entity.InternalNotes = request.InternalNotes;
        entity.PrivateNotes = request.PrivateNotes;
        entity.TicketId = request.TicketId;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
