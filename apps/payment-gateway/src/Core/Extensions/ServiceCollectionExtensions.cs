using PaymentGateway.APIs;

namespace PaymentGateway;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddScoped<IPaymentsService, PaymentsService>();
    }
}
