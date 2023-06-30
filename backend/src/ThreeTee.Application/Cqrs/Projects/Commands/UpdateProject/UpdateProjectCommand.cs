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

        //var project = _context.Projects.FirstOrDefault(p => p.Id == request.Id);

        //if (project is null)
        //    return default;

        ////_context.Projects.Update(project);

        //project.Name = request.Name;
        //project.StartDate = DateTime.SpecifyKind(DateTime.Parse("2023-06-04T16:55:44.501Z"), DateTimeKind.Utc);
        //project.EndDate = request.EndDate;
        //project.BillingPrice = request.BillingPrice;
        //project.ClientId=request.ClientId;
        var entity = request.Adapt<Project>();
        _context.Projects.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}

