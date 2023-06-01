using ThreeTee.Application.Models.BillingTypes;

namespace ThreeTee.Application.Interfaces;

public interface IBillingTypeService
{
    Task<IEnumerable<BillingTypeResponse>> GetAsync(Guid? id);
}