namespace Nucleus.Domain.CompanyAggregate.Entities;

public class Company : BaseAuditableEntity
{
    private string? _identifier;

    public string? Identifier
    {
        get => _identifier;
        set => _identifier = value?.ToUpper();
    }

    public string? Name { get; set; }
    
    public int? ParentCompanyId { get; set; }
    public Company? ParentCompany { get; set; }
}
