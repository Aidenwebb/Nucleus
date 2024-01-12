using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.TimeEntryAggregate.Entities;

namespace Nucleus.Application.TimeEntries.Queries.GetTimeEntry;

public record GetTimeEntryQuery(int Id) : IRequest<TimeEntryDetailDto>;

public class GetTimeEntryQueryValidator : AbstractValidator<GetTimeEntryQuery>
{
    public GetTimeEntryQueryValidator()
    {
    }
}

public class GetTimeEntryQueryHandler : IRequestHandler<GetTimeEntryQuery, TimeEntryDetailDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTimeEntryQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TimeEntryDetailDto> Handle(GetTimeEntryQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.TimeEntries
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        return _mapper.Map<TimeEntry, TimeEntryDetailDto>(entity);
    }
}
