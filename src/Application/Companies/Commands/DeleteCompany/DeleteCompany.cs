using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.CompanyAggregate.Events;

namespace Nucleus.Application.Companies.Commands.DeleteCompany;

public record DeleteCompanyCommand(int Id) : IRequest;

public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyCommandValidator()
    {
    }
}

public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCompanyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Companies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Companies.Remove(entity);
        
        entity.AddDomainEvent(new CompanyDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
