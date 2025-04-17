using Application.DTOs.BookingDtos;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingCQRS.Queries.GetBookingHistory
{
    public class GetBookingHistoryQuery : IRequest<OperationResult<List<BookingHistoryDto>>>
    {
        public int CustomerId { get; set; }
        public GetBookingHistoryQuery(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
