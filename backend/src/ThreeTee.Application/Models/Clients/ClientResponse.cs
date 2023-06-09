﻿
namespace ThreeTee.Application.Models.Clients;

public class ClientResponse : ClientPostRequest
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? LastTouchedBy { get; set; }
}
