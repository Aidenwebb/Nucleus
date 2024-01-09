using Nucleus.Domain.CompanyAggregate;

namespace Nucleus.Application.Companies.Queries.GetCompaniesWithPagination;

public class CompanyBriefDto
{
    
    public int Id { get; init; }

    public int ParentCompanyId { get; init; }

    public string? Identifier { get; init; }

    public string? Name { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Company, CompanyBriefDto>();
        }
    }
}
