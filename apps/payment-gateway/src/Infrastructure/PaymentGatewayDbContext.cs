using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Infrastructure.Models;

namespace PaymentGateway.Infrastructure;

public class PaymentGatewayDbContext : IdentityDbContext<IdentityUser>
{
    public PaymentGatewayDbContext(DbContextOptions<PaymentGatewayDbContext> options)
        : base(options) { }

    public DbSet<CustomerDbModel> Customers { get; set; }

    public DbSet<PaymentDbModel> Payments { get; set; }
}
