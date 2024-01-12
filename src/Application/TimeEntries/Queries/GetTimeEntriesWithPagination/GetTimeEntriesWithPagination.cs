using Nucleus.Application.Common.Interfaces;
using Nucleus.Application.Common.Mappings;
using Nucleus.Application.Common.Models;

namespace Nucleus.Application.TimeEntries.Queries.GetTimeEntriesWithPagination;

public record GetTimeEntriesWithPaginationQuery : IRequest<PaginatedList<TimeEntryBriefDto>>
{
    public int? PageNumber { get; init; } = 1;
    public int? PageSize { get; init; } = 10;
}

public class GetTimeEntriesWithPaginationQueryValidator : AbstractValidator<GetTimeEntriesWithPaginationQuery>
{
    public GetTimeEntriesWithPaginationQueryValidator()
    {
    }
}

public class GetTimeEntriesWithPaginationQueryHandler : IRequestHandler<GetTimeEntriesWithPaginationQuery, PaginatedList<TimeEntryBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTimeEntriesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TimeEntryBriefDto>> Handle(GetTimeEntriesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.TimeEntries
            .OrderBy(x => x.TimeStart)
            .ProjectTo<TimeEntryBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
