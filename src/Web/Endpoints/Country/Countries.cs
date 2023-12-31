using Microsoft.Extensions.DependencyInjection.Countries.Queries;
using Nucleus.Application.Common.Models;
using Nucleus.Application.Countries.Commands.CreateCountry;
using Nucleus.Application.Countries.Queries.GetCountriesWithPagination;

namespace Nucleus.Web.Endpoints.Country;

public class Countries : EndpointGroupBase

{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            // .RequireAuthorization()
            .MapGet(GetCountriesWithPagination)
            .MapPost(CreateCountry);
        // .MapPut(UpdateTodoItem, "{id}")
        // .MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
        // .MapDelete(DeleteTodoItem, "{id}");
    }
    public async Task<int> CreateCountry(ISender sender, CreateCountryCommand command)
    {
        return await sender.Send(command);
    }
    
    public async Task<PaginatedList<CountryBriefDto>> GetCountriesWithPagination(ISender sender, [AsParameters] GetCountriesWithPaginationQuery query)
    {
        return await sender.Send(query);
    }
}
