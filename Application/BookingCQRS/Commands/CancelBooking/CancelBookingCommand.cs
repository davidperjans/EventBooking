using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingCQRS.Commands.CancelBooking
{
    public class CancelBookingCommand : IRequest<OperationResult<string>>
    {
        public int TicketId { get; set; }
        public CancelBookingCommand(int ticketId)
        {
            TicketId = ticketId;
        }
    }
}
