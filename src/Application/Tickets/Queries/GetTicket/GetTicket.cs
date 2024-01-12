using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.TicketAggregate.Entities;

namespace Nucleus.Application.Tickets.Queries.GetTicket;

public record GetTicketQuery(int Id) : IRequest<TicketDetailDto>;

public class GetTicketQueryValidator : AbstractValidator<GetTicketQuery>
{
    public GetTicketQueryValidator()
    {
    }
}

public class GetTicketQueryHandler : IRequestHandler<GetTicketQuery, TicketDetailDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTicketQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TicketDetailDto> Handle(GetTicketQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tickets
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        return _mapper.Map<Ticket, TicketDetailDto>(entity);
    }
}
