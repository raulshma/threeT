using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Mappers;
using ThreeTee.Application.Models.Departments;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Services;

internal class DepartmentService : IDepartmentService
{
    private readonly IGenericRepository<Department> _repository;
    private readonly DepartmentMapper _mapper;
    public DepartmentService(IGenericRepository<Department> repository)
    {
        _repository = repository;
        _mapper = new DepartmentMapper();
    }

    public async Task<IEnumerable<DepartmentResponse>> GetAsync()
    {
        IEnumerable<Department>? items = await _repository.GetAsync();
        if (!items.Any()) return Enumerable.Empty<DepartmentResponse>();

        return _mapper.ToDto(items);
    }

    public async Task<DepartmentResponse?> GetByIdAsync(Guid? id)
    {
        var item = await _repository.GetByIDAsync(id);

        if (item == null) return null;

        return _mapper.ToDto(item);
    }

    public async Task<DepartmentResponse> InsertAsync(DepartmentPostRequest request)
    {
        var result = await _repository.InsertAsync(_mapper.ToEntity(request));
        await _repository.SaveChangesAsync();
        return _mapper.ToDto(result);
    }

    public async Task DeleteAsync(Guid id)
    {
        _repository.Delete(id);
        await _repository.SaveChangesAsync();
    }

    public async Task<DepartmentResponse?> Update(DepartmentPutRequest request)
    {
        var result = await _repository.UpdateAsync(_mapper.ToEntity(request));
        await _repository.SaveChangesAsync();
        return _mapper.ToDto(result);
    }

    public async Task<DepartmentResponse> UpdateAsync(DepartmentPutRequest request)
    {
        var model = _mapper.ToEntity(request);
        _repository.Update(model);
        await _repository.SaveChangesAsync();
        return _mapper.ToDto(model);
    }
}
