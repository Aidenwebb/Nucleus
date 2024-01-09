using Nucleus.Application.Common.Interfaces;
using Nucleus.Application.Common.Mappings;
using Nucleus.Application.Common.Models;

namespace Nucleus.Application.Companies.Queries.GetCompaniesWithPagination;

public record GetCompaniesWithPaginationQuery : IRequest<PaginatedList<CompanyBriefDto>>
{
    public int? PageNumber { get; init; } = 1;
    public int? PageSize { get; init; } = 10;
}

public class GetCompaniesWithPaginationQueryValidator : AbstractValidator<GetCompaniesWithPaginationQuery>
{
    public GetCompaniesWithPaginationQueryValidator()
    {
    }
}

public class GetCompaniesWithPaginationQueryHandler : IRequestHandler<GetCompaniesWithPaginationQuery, PaginatedList<CompanyBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCompaniesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CompanyBriefDto>> Handle(GetCompaniesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Companies
            .OrderBy(x => x.Identifier)
            .ProjectTo<CompanyBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
