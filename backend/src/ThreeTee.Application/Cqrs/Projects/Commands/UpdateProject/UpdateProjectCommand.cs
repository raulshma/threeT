using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Cqrs.Projects.Commands.UpdateProject;
public record class UpdateProjectCommand : IRequest<Project>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public double? BillingPrice { get; set; }
    public required Guid ClientId { get; set; }
}

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Project>
{
    private readonly IEntitiesContext _context;
    public UpdateProjectCommandHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<Project> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Project>();
        _context.Projects.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}

