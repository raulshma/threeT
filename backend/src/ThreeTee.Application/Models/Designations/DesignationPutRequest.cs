using System.ComponentModel.DataAnnotations;

namespace ThreeTee.Application.Models.Designations;

public class DesignationPutRequest : DesignationPostRequest
{
    [Required]
    public Guid Id { get; set; }
}
