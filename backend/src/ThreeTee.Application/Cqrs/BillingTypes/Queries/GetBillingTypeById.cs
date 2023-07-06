using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreeTee.Application.Models.BillingTypes;

namespace ThreeTee.Application.Cqrs.BillingTypes.Queries;
public class GetBillingTypeByIdQuery:IRequest<BillingTypeResponse>
{
    public Guid Id { get; set; }
}

public class GetBillingTypeByIdQueryHandler : IRequestHandler<GetBillingTypeByIdQuery, BillingTypeResponse>
{
    private readonly IEntitiesContext _context;
    public GetBillingTypeByIdQueryHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<BillingTypeResponse> Handle(GetBillingTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _context.BillingTypes.ProjectToType<BillingTypeResponse>().FirstOrDefaultAsync(e=>e.Id == request.Id);
        if(item == null) { return null; }
        return item;
    }
}

