using PaymentGateway.APIs.Common;
using PaymentGateway.APIs.Dtos;

namespace PaymentGateway.APIs;

public interface ICustomersService
{
    /// <summary>
    /// Create one customer
    /// </summary>
    public Task<Customer> CreateCustomer(CustomerCreateInput customer);

    /// <summary>
    /// Delete one customer
    /// </summary>
    public Task DeleteCustomer(CustomerWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many customers
    /// </summary>
    public Task<List<Customer>> Customers(CustomerFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about customer records
    /// </summary>
    public Task<MetadataDto> CustomersMeta(CustomerFindManyArgs findManyArgs);

    /// <summary>
    /// Get one customer
    /// </summary>
    public Task<Customer> Customer(CustomerWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one customer
    /// </summary>
    public Task UpdateCustomer(CustomerWhereUniqueInput uniqueId, CustomerUpdateInput updateDto);

    /// <summary>
    /// Connect multiple payments records to customer
    /// </summary>
    public Task ConnectPayments(
        CustomerWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Disconnect multiple payments records from customer
    /// </summary>
    public Task DisconnectPayments(
        CustomerWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Find multiple payments records for customer
    /// </summary>
    public Task<List<Payment>> FindPayments(
        CustomerWhereUniqueInput uniqueId,
        PaymentFindManyArgs PaymentFindManyArgs
    );

    /// <summary>
    /// Update multiple payments records for customer
    /// </summary>
    public Task UpdatePayments(
        CustomerWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );
}
