using Nucleus.Application.Common.Interfaces;
using Nucleus.Application.Common.Mappings;
using Nucleus.Application.Common.Models;
using Nucleus.Application.Countries.Queries.GetCountriesWithPagination;
using Nucleus.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace Microsoft.Extensions.DependencyInjection.Countries.Queries;

public class GetCountriesWithPaginationQuery : IRequest<PaginatedList<CountryBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class
    GetCountriesWithPaginationQueryHandler : IRequestHandler<GetCountriesWithPaginationQuery,
    PaginatedList<CountryBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCountriesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CountryBriefDto>> Handle(GetCountriesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Countries
            .OrderBy(x => x.Name)
            .ProjectTo<CountryBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
