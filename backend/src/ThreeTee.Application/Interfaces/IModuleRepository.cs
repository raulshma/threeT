using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Interfaces;
public interface IModuleRepository
{
    //T GetByProjectId(Guid? id);
    Task<IEnumerable<Module>> GetByProjectId(Guid? Id);
    //Task<IEnumerable<T>> DeleteByProjectId(Guid? ProjectId);
    void DeleteByProjectIdAsync(Guid? ProjectId);
}
