using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.CompanyAggregate.Entities;
using Nucleus.Domain.CompanyAggregate.Events;

namespace Nucleus.Application.Companies.Commands.CreateCompany;

public record CreateCompanyCommand : IRequest<int>
{
    public string? Identifier { get; set; }
    public string? Name { get; set; }
    
    public int? ParentCompanyId { get; set; }
}

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(v => v.Identifier)
            .MaximumLength(10)
            .NotEmpty();

        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCompanyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = new Company
        {
            Identifier = request.Identifier, Name = request.Name, ParentCompanyId = request.ParentCompanyId
        };
        
        entity.AddDomainEvent(new CompanyCreatedEvent(entity));

        _context.Companies.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
