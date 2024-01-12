using Nucleus.Application.Common.Models;
using Nucleus.Application.TimeEntries.Commands.CreateTimeEntry;
using Nucleus.Application.TimeEntries.Commands.DeleteTimeEntry;
using Nucleus.Application.TimeEntries.Commands.UpdateTimeEntry;
using Nucleus.Application.TimeEntries.Queries.GetTimeEntriesWithPagination;
using Nucleus.Application.TimeEntries.Queries.GetTimeEntry;

namespace Nucleus.Web.Endpoints.TimeEntry;

public class TimeEntries : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateTimeEntry)
            .MapGet(GetTimeEntryById, "{id}")
            .MapGet(GetTimeEntriesWithPagination)
            .MapPut(UpdateTimeEntry, "{id}")
            // .MapPut(UpdateTimeEntryDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteTimeEntry, "{id}");
    }
    
    public async Task<int> CreateTimeEntry(ISender sender, CreateTimeEntryCommand command)
    {
        return await sender.Send(command);
    }
    
    public async Task<TimeEntryDetailDto> GetTimeEntryById(ISender sender, [AsParameters] GetTimeEntryQuery query)
    {
        return await sender.Send(query);
    }
    
    public async Task<PaginatedList<TimeEntryBriefDto>> GetTimeEntriesWithPagination(ISender sender, [AsParameters] GetTimeEntriesWithPaginationQuery query)
    {
        return await sender.Send(query);
    }
    
    public async Task<IResult> UpdateTimeEntry(ISender sender, int id, UpdateTimeEntryCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
    
    public async Task<IResult> DeleteTimeEntry(ISender sender, int id)
    {
        await sender.Send(new DeleteTimeEntryCommand(id));
        return Results.NoContent();
    }
}
