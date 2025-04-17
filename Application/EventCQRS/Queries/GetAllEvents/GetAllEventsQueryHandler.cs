using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventCQRS.Queries.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, OperationResult<IEnumerable<Event>>>
    {
        private readonly IGenericRepository<Event> _repository;

        public GetAllEventsQueryHandler(IGenericRepository<Event> repository)
        {
            _repository = repository;
        }
        public Task<OperationResult<IEnumerable<Event>>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAllAsync();
        }
    }
}
