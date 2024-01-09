using Nucleus.Domain.CompanyAggregate.Entities;

namespace Nucleus.Domain.CompanyAggregate.Events;

public class CompanyDeletedEvent : BaseEvent
{
    public CompanyDeletedEvent(Company company)
    {
        Company = company;
    }

    public Company Company { get; }
}
