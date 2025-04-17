using Application.DTOs.BookingDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingCQRS.Queries.GetBookingHistory
{
    public class GetBookingHistoryQueryHandler : IRequestHandler<GetBookingHistoryQuery, OperationResult<List<BookingHistoryDto>>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        public GetBookingHistoryQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<BookingHistoryDto>>> Handle(GetBookingHistoryQuery request, CancellationToken cancellationToken)
        {
            var allTicketsResult = await _ticketRepository.GetTicketsWithEventsAsync();

            if (!allTicketsResult.IsSuccess || allTicketsResult.Data == null)
                return OperationResult<List<BookingHistoryDto>>.Failure("Failed to retrieve booking history.");

            var tickets = allTicketsResult.Data.Where(ticket => ticket.CustomerId == request.CustomerId).ToList();

            var bookingDtos = _mapper.Map<List<BookingHistoryDto>>(tickets);

            return OperationResult<List<BookingHistoryDto>>.Success(bookingDtos);
        }
    }
}
