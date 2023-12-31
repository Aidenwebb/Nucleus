using Nucleus.Domain.Entities.Countries;

namespace Nucleus.Domain.Events;

public class CountryCreatedEvent : BaseEvent
{
    public CountryCreatedEvent(Country country)
    {
        Country = country;
    }
    
    public Country Country { get; }
}
