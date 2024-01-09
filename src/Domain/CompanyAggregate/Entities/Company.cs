namespace Nucleus.Domain.CompanyAggregate;

public class Company : BaseAuditableEntity
{
    public string? Identifier { get; set; }
    public string? Name { get; set; }
    
    public int? ParentCompanyId { get; set; }
    public Company? ParentCompany { get; set; }
}
