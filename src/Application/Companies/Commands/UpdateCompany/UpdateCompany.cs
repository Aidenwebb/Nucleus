using Nucleus.Application.Common.Interfaces;

namespace Nucleus.Application.Companies.Commands.UpdateCompany;

public record UpdateCompanyCommand : IRequest
{
    public int Id { get; init; }
    public string? Identifier { get; init; }
    public string? Name { get; init; }
    
    public int? ParentCompanyId { get; init; }
}

public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyCommandValidator()
    {
        RuleFor(v => v.Identifier)
            .MaximumLength(10)
            .NotEmpty();

        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCompanyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Companies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Identifier = request.Identifier;
        entity.Name = request.Name;
        entity.ParentCompanyId = request.ParentCompanyId;

        await _context.SaveChangesAsync(cancellationToken);
    }
    
}
