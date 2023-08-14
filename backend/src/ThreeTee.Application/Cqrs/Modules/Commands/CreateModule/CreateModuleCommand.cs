using Mapster;
using MediatR;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Cqrs.Modules.Commands.CreateModule;
public class CreateModuleCommand : IRequest<Module>
{
    public string Name { get; set; }
    public Guid ProjectId { get; set; }
}

public class CreateModuleCommandHandler : IRequestHandler<CreateModuleCommand, Module>
{
    private readonly IEntitiesContext _context;
    public CreateModuleCommandHandler(IEntitiesContext context)
    {
        _context= context;
    }
    public async Task<Module> Handle(CreateModuleCommand request, CancellationToken cancellationToken)
    {
        var module = request.Adapt<Module>();

        _context.Modules.Add(module);
        var result = await _context.SaveChangesAsync(cancellationToken);
        if (result != 0)
            return module;
        else
            return null;
    }
}
