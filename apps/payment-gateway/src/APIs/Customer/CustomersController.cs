using Microsoft.AspNetCore.Mvc;

namespace PaymentGateway.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
