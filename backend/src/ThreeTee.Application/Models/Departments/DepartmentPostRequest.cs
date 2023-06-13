using System.ComponentModel.DataAnnotations;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Models.Departments;

public class DepartmentPostRequest
{
    public string Name { get; set; }
    public string Code { get; set; }
    //public virtual ICollection<DepartmentManager> DepartmentManagers { get; set; }
}

