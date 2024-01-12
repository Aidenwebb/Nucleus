using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.TicketAggregate.Entities;
using Nucleus.Domain.TimeEntryAggregate.Entities;
using Nucleus.Domain.TimeEntryAggregate.Enums;
using Nucleus.Domain.TimeEntryAggregate.Events;

namespace Nucleus.Application.TimeEntries.Commands.CreateTimeEntry;

public record CreateTimeEntryCommand : IRequest<int>
{
    public int CompanyId { get; set; }

    public ChargeToType? ChargeToType { get; set; }
    public DateTime? TimeStart { get; set; }
    public int? TicketId { get; set; }
}

public class CreateTimeEntryCommandValidator : AbstractValidator<CreateTimeEntryCommand>
{
    public CreateTimeEntryCommandValidator()
    {
        RuleFor(v => v.CompanyId)
            .NotEmpty();
    }
}

public class CreateTimeEntryCommandHandler : IRequestHandler<CreateTimeEntryCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IUser _user;

    public CreateTimeEntryCommandHandler(IApplicationDbContext context, IUser user)
    {
        _context = context;
        _user = user;
    }

    public async Task<int> Handle(CreateTimeEntryCommand request, CancellationToken cancellationToken)
    {
        var entity = new TimeEntry()
        {
            CompanyId = request.CompanyId,
            ChargeToType = request.ChargeToType,
            TimeStart = request.TimeStart ?? DateTime.UtcNow,
            TicketId = request.TicketId,
            EnteredBy = _user.Id
        };
        
        
        entity.AddDomainEvent(new TimeEntryCreatedEvent(entity));

        _context.TimeEntries.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
