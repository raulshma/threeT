using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Mappers;
using ThreeTee.Application.Models.Designations;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Services;

internal class DesignationService : IDesignationService
{
    private readonly IGenericRepository<Designation> _repository;
    private readonly DesignationMapper _mapper;
    public DesignationService(IGenericRepository<Designation> repository)
    {
        _repository = repository;
        _mapper = new DesignationMapper();
    }

    public async Task<IEnumerable<DesignationResponse>> GetAsync()
    {
        IEnumerable<Designation>? items = await _repository.GetAsync();
        if (!items.Any()) return Enumerable.Empty<DesignationResponse>();

        return _mapper.ToDto(items);
    }

    public async Task DeleteAsync(Guid id)
    {
        _repository.Delete(id);
        await _repository.SaveChangesAsync();
    }

    public async Task<DesignationResponse?> GetByIdAsync(Guid? id)
    {
        var item = await _repository.GetByIDAsync(id);
        if (item == null) return null;

        return _mapper.ToDto(item);
    }

    public async Task<DesignationResponse> InsertAsync(DesignationPostRequest request)
    {
        var result = await _repository.InsertAsync(_mapper.ToEntity(request));
        await _repository.SaveChangesAsync();
        return _mapper.ToDto(result);
    }

    public async Task<DesignationResponse> UpdateAsync(DesignationPutRequest request)
    {
        var result = await _repository.UpdateAsync(_mapper.ToEntity(request));
        await _repository.SaveChangesAsync();
        return _mapper.ToDto(result);
    }
}

