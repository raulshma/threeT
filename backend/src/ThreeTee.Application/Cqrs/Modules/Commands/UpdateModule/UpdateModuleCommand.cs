using Mapster;
using MediatR;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Cqrs.Modules.Commands.UpdateModule;

public class UpdateModuleCommand:IRequest<Module>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ProjectId { get; set; }
}

public class UpdateModuleCommandHandler : IRequestHandler<UpdateModuleCommand, Module>
{
    private readonly IEntitiesContext _context;
    public UpdateModuleCommandHandler(IEntitiesContext context)
    {
        _context= context;
    }
    public async Task<Module> Handle(UpdateModuleCommand request, CancellationToken cancellationToken)
    {
        var module = request.Adapt<Module>();
        _context.Modules.Update(module);

        await _context.SaveChangesAsync(cancellationToken);
        return module;
    }
}
