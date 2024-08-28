namespace PaymentGateway.APIs.Dtos;

public class PaymentUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Customer { get; set; }

    public string? Id { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
