using Microsoft.AspNetCore.Mvc;
using PaymentGateway.APIs.Common;
using PaymentGateway.Infrastructure.Models;

namespace PaymentGateway.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class PaymentFindManyArgs : FindManyInput<Payment, PaymentWhereInput> { }
