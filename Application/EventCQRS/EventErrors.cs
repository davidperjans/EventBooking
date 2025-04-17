using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventCQRS
{
    public static class EventErrors
    {
        public const string EventNotFound = "Event not found.";
        public const string InvalidEventType = "Invalid event type.";
        public const string EventCreationFailed = "Failed to create event.";
        public const string EventUpdateFailed = "Failed to update event.";
        public const string EventDeletionFailed = "Failed to delete event.";
        public const string InvalidEventDate = "Invalid event date.";
        public const string NoAvailableTickets = "No available tickets for this event.";
        public const string TicketAlreadyBooked = "Ticket already booked.";
        public const string InvalidTotalTickets = "Total tickets cannot be less than available tickets";
    }
}
