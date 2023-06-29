using Mapster;
using MediatR;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Cqrs.ProjectUsers.Commands.CreateProjectUser;

public record CreateProjectUserCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
}

public class CreateProjectUserCommandHandler : IRequestHandler<CreateProjectUserCommand, Guid>
{
    private readonly IEntitiesContext _context;

    public CreateProjectUserCommandHandler(IEntitiesContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateProjectUserCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<ProjectUser>();
        //var entitys = new ProjectUser
        //{
        //    ProjectId = request.ProjectId,
        //    UserId = entity.UserId,
        //};

        // entity.AddDomainEvent(new ProjectUserCreatedEvent(entity));

        _context.ProjectUsers.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.UserId;
    }
}