﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThreeTee.Core.Entities;
public class Client : BaseEntityWithKey<Guid>
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime BoardedOn { get; set; }
    public Guid BoardedById { get; set; }
    [ForeignKey(nameof(BoardedById))]
    public ApplicationUser? BoardedBy { get; set; }
    public string? Country { get; set; }
    [Required]
    public bool IsActive { get; set; }
    public Guid BillingTypeId { get; set; }
    public virtual BillingType? BillingType { get; set; }
    public virtual ICollection<Project> Projects { get; set; }
}
