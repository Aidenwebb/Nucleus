using Nucleus.Application.Common.Interfaces;
using Nucleus.Application.Common.Mappings;
using Nucleus.Application.Common.Models;

namespace Nucleus.Application.Contacts.Queries.GetContactsWithPagination;

public record GetContactsWithPaginationQuery : IRequest<PaginatedList<ContactBriefDto>>
{
    public int CompanyId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetContactsWithPaginationQueryValidator : AbstractValidator<GetContactsWithPaginationQuery>
{
    public GetContactsWithPaginationQueryValidator()
    {
    }
}

public class GetContactsWithPaginationQueryHandler : IRequestHandler<GetContactsWithPaginationQuery, PaginatedList<ContactBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContactsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ContactBriefDto>> Handle(GetContactsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Contacts
            .Where(x => x.CompanyId == request.CompanyId)
            .OrderBy(x => x.FamilyName)
            .ProjectTo<ContactBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
