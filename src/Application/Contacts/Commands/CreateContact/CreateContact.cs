using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.ContactAggregate.Entities;
using Nucleus.Domain.ContactAggregate.Events;

namespace Nucleus.Application.Contacts.Commands.CreateContact;

public record CreateContactCommand : IRequest<int>
{
    public int CompanyId { get; init; }
    public string? GivenName { get; init; }
    public string? FamilyName { get; init; }
}

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(v => v.GivenName)
            .MaximumLength(200);

        RuleFor(v => v.FamilyName)
            .MaximumLength(200);
    }
}

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateContactCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var entity = new Contact
        {
            CompanyId = request.CompanyId, GivenName = request.GivenName, FamilyName = request.FamilyName,
        };
        
        entity.AddDomainEvent(new ContactCreatedEvent(entity));

        _context.Contacts.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
