using PaymentGateway.Infrastructure;

namespace PaymentGateway.APIs;

public class PaymentsService : PaymentsServiceBase
{
    public PaymentsService(PaymentGatewayDbContext context)
        : base(context) { }
}
