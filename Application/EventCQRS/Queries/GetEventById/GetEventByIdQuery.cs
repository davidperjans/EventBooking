using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventCQRS.Queries.GetEventById
{
    public class GetEventByIdQuery : IRequest<OperationResult<Event>>
    {
        public int Id { get; set; }

        public GetEventByIdQuery(int id)
        {
            Id = id;
        }
    }
}
