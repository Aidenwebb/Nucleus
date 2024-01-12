using Nucleus.Application.Common.Interfaces;
using Nucleus.Application.Common.Mappings;
using Nucleus.Application.Common.Models;
using Nucleus.Application.Companies.Queries.GetCompaniesWithPagination;

namespace Nucleus.Application.Tickets.Queries.GetTicketsWithPagination;

public record GetTicketsWithPaginationQuery : IRequest<PaginatedList<TicketBriefDto>>
{
    public int? PageNumber { get; init; } = 1;
    public int? PageSize { get; init; } = 10;
}

public class GetTicketsWithPaginationQueryValidator : AbstractValidator<GetTicketsWithPaginationQuery>
{
    public GetTicketsWithPaginationQueryValidator()
    {
    }
}

public class GetTicketsWithPaginationQueryHandler : IRequestHandler<GetTicketsWithPaginationQuery, PaginatedList<TicketBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTicketsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TicketBriefDto>> Handle(GetTicketsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tickets
            .OrderBy(x => x.Id)
            .ProjectTo<TicketBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
