namespace PaymentGateway.APIs.Dtos;

public class CustomerCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? FirstName { get; set; }

    public string? Id { get; set; }

    public string? LastName { get; set; }

    public List<Payment>? Payments { get; set; }

    public DateTime UpdatedAt { get; set; }
}
