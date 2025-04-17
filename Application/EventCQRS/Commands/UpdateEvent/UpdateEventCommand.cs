using Domain.Enums;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventCQRS.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest<OperationResult<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public TypeOfEvent Type { get; set; }
        public int TotalTickets { get; set; }
        public UpdateEventCommand(int id, string name, DateTime startDate, DateTime endDate, string location, TypeOfEvent type, int totalTickets)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Location = location;
            Type = type;
            TotalTickets = totalTickets;
        }
    }
}
