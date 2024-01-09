using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.CompanyAggregate.Entities;

namespace Nucleus.Application.Companies.Queries.GetCompany;

public record GetCompanyQuery(int Id) : IRequest<CompanyDetailDto>;

public class GetCompanyQueryValidator : AbstractValidator<GetCompanyQuery>
{
    public GetCompanyQueryValidator()
    {
    }
}

public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyDetailDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCompanyQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CompanyDetailDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Companies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        return _mapper.Map<Company, CompanyDetailDto>(entity);
    }
}
