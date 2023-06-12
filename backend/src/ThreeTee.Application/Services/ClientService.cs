using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Mappers;
using ThreeTee.Application.Models.Clients;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Services
{
    internal class ClientService : IClientService
    {
        private readonly IGenericRepository<Client> _repository;
        private readonly ClientMapper _mapper;
        public ClientService(IGenericRepository<Client> repository)
        {
            _repository = repository;
            _mapper = new ClientMapper();
        }

        public async Task<IEnumerable<ClientResponse>> GetAsync()
        {
            IEnumerable<Client>? items = await _repository.GetAsync();
            if (!items.Any()) return Enumerable.Empty<ClientResponse>();
            
            return _mapper.ToDto(items);
        }

        public async Task<ClientResponse?> GetByIdAsync(Guid? id)
        {
            var item = await _repository.GetByIDAsync(id);

            if (item == null) return null;

            return _mapper.ToDto(item);
        }

        public async Task<ClientResponse> InsertAsync(ClientPostRequest request)
        {
            var result = await _repository.InsertAsync(_mapper.ToEntity(request));
            await _repository.SaveChangesAsync();
            return _mapper.ToDto(result);
        }
        
        public async Task<ClientResponse> UpdateAsync(ClientPutRequest request)
        {
            var model = _mapper.ToEntity(request);
            _repository.Update(model);
            await _repository.SaveChangesAsync();
            return _mapper.ToDto(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            _repository.Delete(id);
            await _repository.SaveChangesAsync();
        }
    }
}
