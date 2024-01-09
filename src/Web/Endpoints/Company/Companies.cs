using Nucleus.Application.Common.Models;
using Nucleus.Application.Companies.Commands.CreateCompany;
using Nucleus.Application.Companies.Queries.GetCompany;

namespace Nucleus.Web.Endpoints.Company;

public class Companies : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateCompany)
            .MapGet(GetCompanyById, "{id}");
        // .MapGet(GetCompaniesWithPagination)

        // .MapPut(UpdateCompany, "{id}")
        // .MapPut(UpdateCompanyDetail, "UpdateDetail/{id}")
        // .MapDelete(DeleteCompany, "{id}");
    }
    
    public async Task<int> CreateCompany(ISender sender, CreateCompanyCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<CompanyDetailDto> GetCompanyById(ISender sender, [AsParameters] GetCompanyQuery query)
    {
        return await sender.Send(query);
    }
    
    // public async Task<PaginatedList<CompanyBriefDto>> GetCompaniesWithPagination(ISender sender, [AsParameters] GetCompaniesWithPaginationQuery query)
    // {
    //     return await sender.Send(query);
    // }
    //
    //
    //
    // public async Task<IResult> UpdateCompany(ISender sender, int id, UpdateCompanyCommand command)
    // {
    //     if (id != command.Id) return Results.BadRequest();
    //     await sender.Send(command);
    //     return Results.NoContent();
    // }
    //
    // public async Task<IResult> UpdateCompanyDetail(ISender sender, int id, UpdateCompanyDetailCommand command)
    // {
    //     if (id != command.Id) return Results.BadRequest();
    //     await sender.Send(command);
    //     return Results.NoContent();
    // }
    //
    // public async Task<IResult> DeleteCompany(ISender sender, int id)
    // {
    //     await sender.Send(new DeleteCompanyCommand(id));
    //     return Results.NoContent();
    // }
}
