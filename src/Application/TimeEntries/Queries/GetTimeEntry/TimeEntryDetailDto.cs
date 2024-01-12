using Nucleus.Domain.CompanyAggregate.Entities;
using Nucleus.Domain.TicketAggregate.Entities;
using Nucleus.Domain.TimeEntryAggregate.Entities;
using Nucleus.Domain.TimeEntryAggregate.Enums;

namespace Nucleus.Application.TimeEntries.Queries.GetTimeEntry;

public class TimeEntryDetailDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    
    public int? ChargeToCompanyId { get; set; }

    public ChargeToType? ChargeToType { get; set; }

    public DateTime TimeStart { get; set; }

    public DateTime? TimeEnd { get; set; }
    public TimeSpan? TimeDelta { get; set; }
    public Decimal HoursDeduct { get; set; }
    public Decimal? HoursActual { get; set; }

    public string? EnteredBy { get; set; }
    
    public string? PublicNotes { get; set; }
    public string? InternalNotes { get; set; }
    public string? PrivateNotes { get; set; }

    public int? TicketId { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TimeEntry, TimeEntryDetailDto>();
        }
    }
}
