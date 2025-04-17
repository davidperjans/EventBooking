using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerCQRS.Queries.GetCustomer
{
    public class GetCustomerQuery : IRequest<OperationResult<Customer>>
    {
        public int Id { get; set; }
        public GetCustomerQuery(int id)
        {
            Id = id;
        }
    }
}
