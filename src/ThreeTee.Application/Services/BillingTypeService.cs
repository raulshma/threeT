using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Mappers;
using ThreeTee.Application.Models.BillingTypes;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Services;
public class BillingTypeService : IBillingTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    public BillingTypeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<BillingTypeResponse>> GetAsync(Guid? id)
    {
        IEnumerable<BillingType>? items;
        if (id == null || id == Guid.Empty)
            items = await _unitOfWork.BillingTypeRepository.GetAsync();
        else
            items = await _unitOfWork.BillingTypeRepository.GetAsync(e => e.Id == id);
        var mapper = new BillingTypeMapper();
        return mapper.BillingTypeToBillingTypeResponse(items);
    }
}
