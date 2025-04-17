using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingCQRS.Commands.CancelBooking
{
    public class CancelBookingCommandHandler : IRequestHandler<CancelBookingCommand, OperationResult<string>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IGenericRepository<Event> _eventRepository;

        public CancelBookingCommandHandler(ITicketRepository ticketRepository, IGenericRepository<Event> eventRepository)
        {
            _ticketRepository = ticketRepository;
            _eventRepository = eventRepository;
        }
        public async Task<OperationResult<string>> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            var ticketResult = await _ticketRepository.GetByIdAsync(request.TicketId);
            if (!ticketResult.IsSuccess || ticketResult.Data == null)
                return OperationResult<string>.Failure("Ticket not found.");

            var eventResult = await _eventRepository.GetByIdAsync(ticketResult.Data.EventId);
            if (!eventResult.IsSuccess || eventResult.Data == null)
                return OperationResult<string>.Failure("Event not found.");

            eventResult.Data.AvailableTickets++;
            await _ticketRepository.DeleteAsync(request.TicketId);

            return OperationResult<string>.Success("Booking cancelled successfully.");
        }
    }
}
