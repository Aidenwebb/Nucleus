namespace Nucleus.Domain.Entities.Companies;

public class CompanyStatus : BaseAuditableEntity
{
    public string? Name { get; set; }
    public bool DefaultFlag { get; set; }
    public bool InactiveFlag { get; set; }
    public bool NotifyFlag { get; set; }
    public bool DisallowSavingFlag { get; set; }
    public string? NotificationMessage { get; set; }
    public bool CustomNoteFlag { get; set; }
}
