using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingCQRS.Commands.BookTicket
{
    public class BookTicketCommandHandler : IRequestHandler<BookTicketCommand, OperationResult<string>>
    {
        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IGenericRepository<Customer> _customerRepository;

        public BookTicketCommandHandler(IGenericRepository<Ticket> ticketRepository, IGenericRepository<Event> eventRepository, IGenericRepository<Customer> customerRepository)
        {
            _ticketRepository = ticketRepository;
            _eventRepository = eventRepository;
            _customerRepository = customerRepository;
        }

        public async Task<OperationResult<string>> Handle(BookTicketCommand request, CancellationToken cancellationToken)
        {
            var eventResult = await _eventRepository.GetByIdAsync(request.EventId);
            if (!eventResult.IsSuccess || eventResult.Data == null)
                return OperationResult<string>.Failure(BookingErrors.EventNotFound);

            var customerResult = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (!customerResult.IsSuccess || customerResult.Data == null)
                return OperationResult<string>.Failure(BookingErrors.CustomerNotFound);

            var eventToBook = eventResult.Data;

            if (eventToBook.AvailableTickets <= 0)
                return OperationResult<string>.Failure(BookingErrors.NoAvailableTickets);

            eventToBook.AvailableTickets--;

            var updateResult = await _eventRepository.UpdateAsync(eventToBook);
            if (!updateResult.IsSuccess)
                return OperationResult<string>.Failure(BookingErrors.EventUpdateFailed);

            var newTicket = new Ticket
            {
                EventId = request.EventId,
                CustomerId = request.CustomerId,
                BookingDate = DateTime.UtcNow
            };

            var ticketResult = await _ticketRepository.AddAsync(newTicket);
            if (!ticketResult.IsSuccess)
                return OperationResult<string>.Failure(BookingErrors.TicketBookingFailed);

            return OperationResult<string>.Success("Ticket booked successfully.");
        }
    }
}
