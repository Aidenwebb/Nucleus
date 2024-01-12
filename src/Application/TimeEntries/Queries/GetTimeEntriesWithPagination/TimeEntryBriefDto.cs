using Nucleus.Domain.TimeEntryAggregate.Entities;
using Nucleus.Domain.TimeEntryAggregate.Enums;

namespace Nucleus.Application.TimeEntries.Queries.GetTimeEntriesWithPagination;

public class TimeEntryBriefDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    
    public int? ChargeToCompanyId { get; set; }

    public ChargeToType? ChargeToType { get; set; }

    public DateTime TimeStart { get; set; }

    public DateTime? TimeEnd { get; set; }

    public string? EnteredBy { get; set; }
    
    public int? TicketId { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TimeEntry, TimeEntryBriefDto>();
        }
    }
}
