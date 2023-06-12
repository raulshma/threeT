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
            
            return _mapper.ToResponse(items);
        }

        public async Task<ClientResponse?> GetByIdAsync(Guid? id)
        {
            var item = await _repository.GetByIDAsync(id);

            if (item == null) return null;

            return _mapper.ToResponse(item);
        }

        public async Task<ClientResponse> InsertAsync(ClientPostRequest request)
        {
            var result = await _repository.InsertAsync(_mapper.ToEntity(request));
            await _repository.SaveChangesAsync();
            return _mapper.ToResponse(result);
        }

        public async Task<ClientResponse?> Update(ClientPutRequest request)
        {
            var result = await _repository.UpdateAsync(_mapper.ToEntity(request));
            await _repository.SaveChangesAsync();
            return _mapper.ToResponse(result);
        }
    }
}
