using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.APIs;
using PaymentGateway.APIs.Common;
using PaymentGateway.APIs.Dtos;
using PaymentGateway.APIs.Errors;

namespace PaymentGateway.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PaymentsControllerBase : ControllerBase
{
    protected readonly IPaymentsService _service;

    public PaymentsControllerBase(IPaymentsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one payment
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Payment>> CreatePayment(PaymentCreateInput input)
    {
        var payment = await _service.CreatePayment(input);

        return CreatedAtAction(nameof(Payment), new { id = payment.Id }, payment);
    }

    /// <summary>
    /// Delete one payment
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeletePayment([FromRoute()] PaymentWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeletePayment(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many payments
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Payment>>> Payments(
        [FromQuery()] PaymentFindManyArgs filter
    )
    {
        return Ok(await _service.Payments(filter));
    }

    /// <summary>
    /// Meta data about payment records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PaymentsMeta(
        [FromQuery()] PaymentFindManyArgs filter
    )
    {
        return Ok(await _service.PaymentsMeta(filter));
    }

    /// <summary>
    /// Get one payment
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Payment>> Payment([FromRoute()] PaymentWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Payment(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one payment
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdatePayment(
        [FromRoute()] PaymentWhereUniqueInput uniqueId,
        [FromQuery()] PaymentUpdateInput paymentUpdateDto
    )
    {
        try
        {
            await _service.UpdatePayment(uniqueId, paymentUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a customer record for payment
    /// </summary>
    [HttpGet("{Id}/customer")]
    public async Task<ActionResult<List<Customer>>> GetCustomer(
        [FromRoute()] PaymentWhereUniqueInput uniqueId
    )
    {
        var customer = await _service.GetCustomer(uniqueId);
        return Ok(customer);
    }
}
