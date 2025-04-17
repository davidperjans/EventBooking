using Application.BookingCQRS.Commands.BookTicket;
using Application.BookingCQRS.Commands.CancelBooking;
using Application.BookingCQRS.Queries;
using Application.BookingCQRS.Queries.GetBookingHistory;
using Application.DTOs.BookingDtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BookingController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("book-ticket")]
        public async Task<IActionResult> BookTicket(BookTicketDto dto)
        {
            var command = _mapper.Map<BookTicketCommand>(dto);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }

        [HttpGet("get-booking-history/{customerId}")]
        public async Task<IActionResult> GetBookingHistory(int customerId)
        {
            var query = new GetBookingHistoryQuery(customerId);

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }

        [HttpDelete("cancel-booking/{ticketId}")]
        public async Task<IActionResult> CancelBooking(int ticketId)
        {
            var command = new CancelBookingCommand(ticketId);

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }
    }
}
