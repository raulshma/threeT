using System.ComponentModel.DataAnnotations;

namespace ThreeTee.Application.Models.Clients
{
    public class ClientPutRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BoardedOn { get; set; }
        public Guid BoardedById { get; set; }
        public Guid BoardedBy { get; set; }
        public string? Country { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public Guid BillingTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
