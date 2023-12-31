using Nucleus.Domain.Entities.Countries;

namespace Nucleus.Domain.Entities.Companies;

public class Company : BaseAuditableEntity
{
    public string? Identifier { get; set; }
    public string? Name { get; set; }
    
    public int CompanyStatusId { get; set; }
    public CompanyStatus Status { get; set; } = null!;
    
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    
    public int? CountryId { get; set; }
    public Country? Country { get; set; }
    
    public string? PhoneNumber { get; set; }
    public string? FaxNumber { get; set; }
    public string? Website { get; set; }
    
    public int? ParentCompanyId { get; set; }
    public Company? ParentCompany { get; set; }
}
