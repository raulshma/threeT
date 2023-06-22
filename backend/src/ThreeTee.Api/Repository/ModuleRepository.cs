using Microsoft.EntityFrameworkCore;
using ThreeTee.Application.Interfaces;
using ThreeTee.Core.Entities;
using ThreeTee.Infrastructure.Persistence.Npgsql.Data;
using ThreeTee.Infrastructure.Repositories;

namespace ThreeTee.Api.Repository
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly EntitiesContext _context;
        
        public ModuleRepository(EntitiesContext context) 
        {
            _context = context;
        }


        public async Task<IEnumerable<Module>> GetByProjectId(Guid? Id)
        {
            var module = _context.Modules.Where(e => e.ProjectId == Id).ToListAsync();
            return (IEnumerable<Module>)await module;
        }

        public async void DeleteByProjectIdAsync(Guid? ProjectId)
        {
            var modules = await _context.Modules.Where(e => e.ProjectId == ProjectId).ToListAsync();
            if (modules.Any())
            {
                _context.Modules.RemoveRange(modules);
            }
        }
    }
}
