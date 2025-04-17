using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventCQRS.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, OperationResult<string>>
    {
        private readonly IGenericRepository<Event> _repository;

        public UpdateEventCommandHandler(IGenericRepository<Event> repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult<string>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            if (!result.IsSuccess || result.Data == null)
                return OperationResult<string>.Failure(EventErrors.EventNotFound);

            var existingEvent = result.Data;

            existingEvent.Name = request.Name;
            existingEvent.StartDate = request.StartDate;
            existingEvent.EndDate = request.EndDate;
            existingEvent.Location = request.Location;
            existingEvent.Type = request.Type;

            if (request.TotalTickets >= (existingEvent.TotalTickets - existingEvent.AvailableTickets))
            {
                int usedTickets = existingEvent.TotalTickets - existingEvent.AvailableTickets;
                existingEvent.TotalTickets = request.TotalTickets;
                existingEvent.AvailableTickets = request.TotalTickets - usedTickets;
            }
            else
            {
                return OperationResult<string>.Failure(EventErrors.InvalidTotalTickets);
            }

            await _repository.UpdateAsync(existingEvent);
            return OperationResult<string>.Success("Event updated successfully");
        }
    }
}
