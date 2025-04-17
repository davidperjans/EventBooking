using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventCQRS.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, OperationResult<string>>
    {
        private readonly IGenericRepository<Event> _repository;

        public CreateEventCommandHandler(IGenericRepository<Event> repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult<string>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = new Event
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Location = request.Location,
                Type = request.Type,
                TotalTickets = request.TotalTickets,
                AvailableTickets = request.TotalTickets
            };

            try
            {
                await _repository.AddAsync(newEvent);
                return OperationResult<string>.Success("Event Created Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return OperationResult<string>.Failure(EventErrors.EventCreationFailed);
            }
        }
    }
}
