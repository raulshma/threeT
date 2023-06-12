using System.ComponentModel.DataAnnotations;

namespace ThreeTee.Application.Models.Clients;

public class ClientPutRequest : ClientPostRequest
{
    [Required]
    public Guid Id { get; set; }
}
