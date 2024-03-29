﻿using Nucleus.Domain.CompanyAggregate.Entities;
using Nucleus.Domain.TicketAggregate.Entities;
using Nucleus.Domain.TimeEntryAggregate.Enums;

namespace Nucleus.Domain.TimeEntryAggregate.Entities;

public class TimeEntry : BaseAuditableEntity
{
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    
    public int? ChargeToCompanyId { get; set; }
    public Company? ChargeToCompany { get; set; }

    public ChargeToType? ChargeToType { get; set; }

    public DateTime TimeStart { get; set; }

    private DateTime? _timeEnd;
    public DateTime? TimeEnd
    {
        get => _timeEnd;
        set
        {
            _timeEnd = value;
            UpdateTimeCalculations();
        }
    }
    
    public TimeSpan? TimeDelta { get; private set; }

    public Decimal HoursDeduct { get; set; } = 0M;

    public Decimal? HoursActual { get; private set; }

    public string? EnteredBy { get; set; }
    
    public string? PublicNotes { get; set; }
    public string? InternalNotes { get; set; }
    public string? PrivateNotes { get; set; }

    public int? TicketId { get; set; }
    public Ticket? Ticket { get; set; }

    private void UpdateTimeCalculations()
    {
        if (TimeEnd.HasValue)
        {
            TimeDelta = TimeEnd.Value - TimeStart;
            HoursActual = Convert.ToDecimal(TimeDelta.Value.TotalHours) - HoursDeduct;

        }
        else
        {
            TimeDelta = null;
            HoursActual = null;
        }
    }
}
