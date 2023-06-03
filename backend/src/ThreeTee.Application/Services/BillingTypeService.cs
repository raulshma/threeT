using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Mappers;
using ThreeTee.Application.Models.BillingTypes;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Services;
public class BillingTypeService : IBillingTypeService
{
    private readonly IGenericRepository<BillingType> _repository;
    public BillingTypeService(IGenericRepository<BillingType> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BillingTypeResponse>> GetAsync(Guid? id)
    {
        IEnumerable<BillingType>? items;
        if (id == null || id == Guid.Empty)
            items = await _repository.GetAsync();
        else
            items = await _repository.GetAsync(e => e.Id == id);
        var mapper = new BillingTypeMapper();
        return mapper.BillingTypeToBillingTypeResponse(items);
    }
}
