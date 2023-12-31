using Nucleus.Application.Common.Interfaces;
using Nucleus.Application.TodoItems.Commands.CreateTodoItem;
using Nucleus.Domain.Entities;
using Nucleus.Domain.Entities.Countries;
using Nucleus.Domain.Events;

namespace Nucleus.Application.Countries.Commands.CreateCountry;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCountryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Country() { Identifier = request.Identifier, Name = request.Name, CountryCode = request.CountryCode};
        
        entity.AddDomainEvent(new CountryCreatedEvent(entity));

        _context.Countries.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
