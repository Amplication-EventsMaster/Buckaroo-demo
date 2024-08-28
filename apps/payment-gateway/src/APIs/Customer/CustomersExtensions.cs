using PaymentGateway.APIs.Dtos;
using PaymentGateway.Infrastructure.Models;

namespace PaymentGateway.APIs.Extensions;

public static class CustomersExtensions
{
    public static Customer ToDto(this CustomerDbModel model)
    {
        return new Customer
        {
            CreatedAt = model.CreatedAt,
            FirstName = model.FirstName,
            Id = model.Id,
            LastName = model.LastName,
            Payments = model.Payments?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CustomerDbModel ToModel(
        this CustomerUpdateInput updateDto,
        CustomerWhereUniqueInput uniqueId
    )
    {
        var customer = new CustomerDbModel
        {
            Id = uniqueId.Id,
            FirstName = updateDto.FirstName,
            LastName = updateDto.LastName
        };

        if (updateDto.CreatedAt != null)
        {
            customer.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            customer.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return customer;
    }
}
