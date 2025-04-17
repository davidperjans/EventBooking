using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerCQRS.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, OperationResult<Customer>>
    {
        private readonly IGenericRepository<Customer> _customerRepository;

        public GetCustomerQueryHandler(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<OperationResult<Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var user = await _customerRepository.GetByIdAsync(request.Id);
            if (!user.IsSuccess)
                return OperationResult<Customer>.Failure(user.ErrorMessage!);

            return OperationResult<Customer>.Success(user.Data!);
        }
    }
}
