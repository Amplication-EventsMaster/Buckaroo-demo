namespace PaymentGateway.APIs.Dtos;

public class PaymentWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Customer { get; set; }

    public string? Id { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
