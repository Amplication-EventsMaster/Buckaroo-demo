namespace PaymentGateway.APIs.Dtos;

public class CustomerWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? FirstName { get; set; }

    public string? Id { get; set; }

    public string? LastName { get; set; }

    public List<string>? Payments { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
