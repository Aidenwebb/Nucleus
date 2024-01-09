using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.ContactAggregate.Entities;

namespace Nucleus.Application.Contacts.Queries.GetContact;

public record GetContactQuery(int Id) : IRequest<ContactDetailDto>;

public class GetContactQueryValidator : AbstractValidator<GetContactQuery>
{
    public GetContactQueryValidator()
    {
    }
}

public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ContactDetailDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContactQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ContactDetailDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Contacts
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        return _mapper.Map<Contact, ContactDetailDto>(entity);
    }
}
