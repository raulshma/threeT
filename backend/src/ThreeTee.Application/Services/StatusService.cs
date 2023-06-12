using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Mappers;
using ThreeTee.Application.Models.Clients;
using ThreeTee.Application.Models.Statuses;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Services
{
    internal class StatusService : IStatusService
    {
        private readonly IGenericRepository<Status> _repository;
        private readonly StatusMapper _mapper;

        public StatusService(IGenericRepository<Status> repository)
        {
            _repository = repository;
            _mapper = new StatusMapper();
        }
        public async Task<IEnumerable<StatusResponse>> GetAsync(Guid? id)
        {
            IEnumerable<Status>? items = await _repository.GetAsync();
            if (!items.Any()) return Enumerable.Empty<StatusResponse>();

            return _mapper.ToResponse(items);
        }

        public async Task<IEnumerable<StatusResponse>> GetAsync()
        {
            IEnumerable<Status>? items = await _repository.GetAsync();
            if (!items.Any()) return Enumerable.Empty<StatusResponse>();
            
            return _mapper.ToResponse(items);
        }

        public async Task<StatusResponse?> GetByIdAsync(Guid? id)
        {
           var item = await _repository.GetByIDAsync(id);
            if (item == null) { return null; }
            return _mapper.ToResponse(item);
        }

        public async Task<StatusResponse> InsertAsync(StatusPostRequest request)
        {
             var result = await _repository.InsertAsync(_mapper.ToEntity(request));
            await _repository.SaveChangesAsync();
            return _mapper.ToResponse(result);
        }
    }
}
