using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventCQRS.Queries.GetEventById
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, OperationResult<Event>>
    {
        private readonly IGenericRepository<Event> _repository;

        public GetEventByIdQueryHandler(IGenericRepository<Event> repository)
        {
            _repository = repository;
        }
        public Task<OperationResult<Event>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetByIdAsync(request.Id);
        }
    }
}
