using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.BookingDtos
{
    public class BookingHistoryDto
    {
        public int TicketId { get; set; }
        public string EventName { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime EventDate { get; set; }
        public int AvailableTicketsLeft { get; set; }
        public string Location { get; set; }
    }
}
