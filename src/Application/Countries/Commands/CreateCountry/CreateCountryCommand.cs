namespace Nucleus.Application.Countries.Commands.CreateCountry;

public record CreateCountryCommand : IRequest<int>
{
    public string? Identifier { get; init; }
    public string? Name { get; init; }
    public string? CountryCode { get; init; }
}
