using Riok.Mapperly.Abstractions;
using ThreeTee.Application.Models.BillingTypes;
using ThreeTee.Core.Entities;
namespace ThreeTee.Application.Mappers;

[Mapper]
public partial class BillingTypeMapper
{
    public partial BillingTypeResponse BillingTypeToBillingTypeResponse(BillingType billingType);
    public partial IEnumerable<BillingTypeResponse> BillingTypeToBillingTypeResponse(IEnumerable<BillingType> billingType);
    public partial BillingType BillingTypeResponseToBillingType(BillingTypeResponse billingTypeResponse);
}
