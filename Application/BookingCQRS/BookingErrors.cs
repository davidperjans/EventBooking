using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingCQRS
{
    public static class BookingErrors
    {
        public const string EventNotFound = "Event not found.";
        public const string CustomerNotFound = "Customer not found.";
        public const string NoAvailableTickets = "No available tickets for this event.";
        public const string TicketBookingFailed = "Failed to book ticket.";
        public const string EventUpdateFailed = "Failed to update event tickets.";
        public const string TicketAlreadyBooked = "Ticket already booked.";
        public const string InvalidBookingDate = "Invalid booking date.";
    }
}
