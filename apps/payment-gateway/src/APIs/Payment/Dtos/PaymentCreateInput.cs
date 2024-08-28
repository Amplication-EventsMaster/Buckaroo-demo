namespace PaymentGateway.APIs.Dtos;

public class PaymentCreateInput
{
    public DateTime CreatedAt { get; set; }

    public Customer? Customer { get; set; }

    public string? Id { get; set; }

    public DateTime UpdatedAt { get; set; }
}
