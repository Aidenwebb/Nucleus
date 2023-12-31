namespace Nucleus.Domain.Entities.Countries;

public class Country : BaseAuditableEntity
{
    public string? Identifier { get; set; }
    public string? Name { get; set; }
    public string? CountryCode { get; set; }
    public bool DefaultFlag { get; set; }
}
