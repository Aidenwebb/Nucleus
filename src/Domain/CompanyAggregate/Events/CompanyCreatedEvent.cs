using Nucleus.Domain.CompanyAggregate.Entities;

namespace Nucleus.Domain.CompanyAggregate.Events;

public class CompanyCreatedEvent : BaseEvent
{
    public CompanyCreatedEvent(Company company)
    {
        Company = company;
    }

    public Company Company { get; }
}
