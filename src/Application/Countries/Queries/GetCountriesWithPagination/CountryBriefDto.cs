using Nucleus.Domain.Entities.Countries;

namespace Nucleus.Application.Countries.Queries.GetCountriesWithPagination;

public class CountryBriefDto
{
    public int Id { get; init; }
    public string? Identifier { get; init; }
    public string? Name { get; init; }
    public string? CountryCode { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Country, CountryBriefDto>();
        }
    }
}
