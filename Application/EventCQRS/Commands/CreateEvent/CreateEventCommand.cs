using Domain.Enums;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventCQRS.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<OperationResult<string>>
    {
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public TypeOfEvent Type { get; set; }
        public int TotalTickets { get; set; }
    }
}
