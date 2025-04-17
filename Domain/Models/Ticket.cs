using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int CustomerId { get; set; }
        public DateTime BookingDate { get; set; }

        public Event Event { get; set; }
    }
}
