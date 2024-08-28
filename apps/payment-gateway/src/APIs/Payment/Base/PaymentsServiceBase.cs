using Microsoft.EntityFrameworkCore;
using PaymentGateway.APIs;
using PaymentGateway.APIs.Common;
using PaymentGateway.APIs.Dtos;
using PaymentGateway.APIs.Errors;
using PaymentGateway.APIs.Extensions;
using PaymentGateway.Infrastructure;
using PaymentGateway.Infrastructure.Models;

namespace PaymentGateway.APIs;

public abstract class PaymentsServiceBase : IPaymentsService
{
    protected readonly PaymentGatewayDbContext _context;

    public PaymentsServiceBase(PaymentGatewayDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one payment
    /// </summary>
    public async Task<Payment> CreatePayment(PaymentCreateInput createDto)
    {
        var payment = new PaymentDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            payment.Id = createDto.Id;
        }
        if (createDto.Customer != null)
        {
            payment.Customer = await _context
                .Customers.Where(customer => createDto.Customer.Id == customer.Id)
                .FirstOrDefaultAsync();
        }

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PaymentDbModel>(payment.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one payment
    /// </summary>
    public async Task DeletePayment(PaymentWhereUniqueInput uniqueId)
    {
        var payment = await _context.Payments.FindAsync(uniqueId.Id);
        if (payment == null)
        {
            throw new NotFoundException();
        }

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many payments
    /// </summary>
    public async Task<List<Payment>> Payments(PaymentFindManyArgs findManyArgs)
    {
        var payments = await _context
            .Payments.Include(x => x.Customer)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return payments.ConvertAll(payment => payment.ToDto());
    }

    /// <summary>
    /// Meta data about payment records
    /// </summary>
    public async Task<MetadataDto> PaymentsMeta(PaymentFindManyArgs findManyArgs)
    {
        var count = await _context.Payments.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one payment
    /// </summary>
    public async Task<Payment> Payment(PaymentWhereUniqueInput uniqueId)
    {
        var payments = await this.Payments(
            new PaymentFindManyArgs { Where = new PaymentWhereInput { Id = uniqueId.Id } }
        );
        var payment = payments.FirstOrDefault();
        if (payment == null)
        {
            throw new NotFoundException();
        }

        return payment;
    }

    /// <summary>
    /// Update one payment
    /// </summary>
    public async Task UpdatePayment(PaymentWhereUniqueInput uniqueId, PaymentUpdateInput updateDto)
    {
        var payment = updateDto.ToModel(uniqueId);

        if (updateDto.Customer != null)
        {
            payment.Customer = await _context
                .Customers.Where(customer => updateDto.Customer == customer.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(payment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Payments.Any(e => e.Id == payment.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Get a customer record for payment
    /// </summary>
    public async Task<Customer> GetCustomer(PaymentWhereUniqueInput uniqueId)
    {
        var payment = await _context
            .Payments.Where(payment => payment.Id == uniqueId.Id)
            .Include(payment => payment.Customer)
            .FirstOrDefaultAsync();
        if (payment == null)
        {
            throw new NotFoundException();
        }
        return payment.Customer.ToDto();
    }
}
