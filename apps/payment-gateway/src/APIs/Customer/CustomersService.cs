using PaymentGateway.Infrastructure;

namespace PaymentGateway.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(PaymentGatewayDbContext context)
        : base(context) { }
}
