using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeTee.Core.Entities;
public class DepartmentManager : BaseEntityWithKey<Guid>
{
    public Guid UserId { get; set; }
    public virtual ApplicationUser User { get; set; }

    public Guid DepartmentId { get; set; }
    public virtual Department Department { get; set; }
}
