using Nucleus.Domain.CompanyAggregate.Entities;

namespace Nucleus.Application.Companies.Queries.GetCompany;

public class CompanyDetailDto
{
    public int Id { get; init; }

    public int ParentCompanyId { get; init; }

    public string? Identifier { get; init; }

    public string? Name { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Company, CompanyDetailDto>();
        }
    }
}
