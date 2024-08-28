using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentGateway.Infrastructure.Models;

[Table("Customers")]
public class CustomerDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? FirstName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? LastName { get; set; }

    public List<PaymentDbModel>? Payments { get; set; } = new List<PaymentDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
