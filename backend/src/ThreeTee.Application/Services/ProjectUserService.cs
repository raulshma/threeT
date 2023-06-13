using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Mappers;
using ThreeTee.Application.Models.ProjectUser;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Services
{
    internal class ProjectUserService : IProjectUserService
    {
        private readonly IGenericRepository<ProjectUser> _repository;
        private readonly ProjectUserMapper _mapper;
        public ProjectUserService(IGenericRepository<ProjectUser> repository)
        {
            _repository = repository;   
            _mapper = new ProjectUserMapper();
        }
        public async Task DeleteAsync(Guid id)
        {
            _repository.Delete(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProjectUserResponse>> GetAsync()
        {
            IEnumerable<ProjectUser>? items = await _repository.GetAsync();
            if (!items.Any()) return Enumerable.Empty<ProjectUserResponse>();

            return _mapper.ToDto(items);
        }

        public async Task<ProjectUserResponse> InsertAsync(ProjectUserUpsertRequest request)
        {
            var result = await _repository.InsertAsync(_mapper.ToEntity(request));
            await _repository.SaveChangesAsync();
            return _mapper.ToDto(result);
        }

        public async Task<ProjectUserResponse> UpdateAsync(ProjectUserUpsertRequest request)
        {
            var model = _mapper.ToEntity(request);
            _repository.Update(model);
            await _repository.SaveChangesAsync();
            return _mapper.ToDto(model);
        }
    }
}

