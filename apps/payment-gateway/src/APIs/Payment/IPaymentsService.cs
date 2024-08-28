using PaymentGateway.APIs.Common;
using PaymentGateway.APIs.Dtos;

namespace PaymentGateway.APIs;

public interface IPaymentsService
{
    /// <summary>
    /// Create one payment
    /// </summary>
    public Task<Payment> CreatePayment(PaymentCreateInput payment);

    /// <summary>
    /// Delete one payment
    /// </summary>
    public Task DeletePayment(PaymentWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many payments
    /// </summary>
    public Task<List<Payment>> Payments(PaymentFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about payment records
    /// </summary>
    public Task<MetadataDto> PaymentsMeta(PaymentFindManyArgs findManyArgs);

    /// <summary>
    /// Get one payment
    /// </summary>
    public Task<Payment> Payment(PaymentWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one payment
    /// </summary>
    public Task UpdatePayment(PaymentWhereUniqueInput uniqueId, PaymentUpdateInput updateDto);

    /// <summary>
    /// Get a customer record for payment
    /// </summary>
    public Task<Customer> GetCustomer(PaymentWhereUniqueInput uniqueId);
}
