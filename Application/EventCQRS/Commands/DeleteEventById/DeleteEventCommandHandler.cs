using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventCQRS.Commands.DeleteEventById
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, OperationResult<string>>
    {
        private readonly IGenericRepository<Event> _repository;

        public DeleteEventCommandHandler(IGenericRepository<Event> repository)
        {
            _repository = repository;
        }
        public Task<OperationResult<string>> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            _repository.DeleteAsync(request.Id);
            return Task.FromResult(OperationResult<string>.Success("Event Deleted Successfully"));
        }
    }
}
