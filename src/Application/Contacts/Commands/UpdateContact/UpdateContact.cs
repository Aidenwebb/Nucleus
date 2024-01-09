using Nucleus.Application.Common.Interfaces;

namespace Nucleus.Application.Contacts.Commands.UpdateContact;

public record UpdateContactCommand : IRequest
{
    public int Id { get; init; }
    public string? GivenName { get; init; }
    public string? FamilyName { get; init; }
    public int? ManagerContactId { get; init; }
    public int? AssistantContactId { get; init; }
}

public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
{
    public UpdateContactCommandValidator()
    {
        RuleFor(v => v.GivenName)
            .MaximumLength(200);

        RuleFor(v => v.FamilyName)
            .MaximumLength(200);
    }
}

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateContactCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Contacts
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.FamilyName = request.FamilyName;
        entity.GivenName = request.GivenName;
        entity.ManagerContactId = request.ManagerContactId;
        entity.AssistantContactId = request.AssistantContactId;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
