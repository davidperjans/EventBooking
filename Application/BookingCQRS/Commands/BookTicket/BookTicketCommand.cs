using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingCQRS.Commands.BookTicket
{
    public class BookTicketCommand : IRequest<OperationResult<string>>
    {
        public int EventId { get; set; }
        public int CustomerId { get; set; }

        public BookTicketCommand(int eventId, int customerId)
        {
            EventId = eventId;
            CustomerId = customerId;
        }
    }
}
