using System.ComponentModel.DataAnnotations;

namespace ThreeTee.Application.Models.Departments;

public class DepartmentPutRequest : DepartmentPostRequest
{
    [Required]
    public Guid Id { get; set; }
}
