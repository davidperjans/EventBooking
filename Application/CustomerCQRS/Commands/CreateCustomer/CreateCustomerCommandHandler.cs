using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerCQRS.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, OperationResult<string>>
    {
        private readonly IGenericRepository<Customer> _customerRepository;

        public CreateCustomerCommandHandler(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<OperationResult<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var newCustomer = new Customer
            {
                FullName = request.FullName,
                Email = request.Email
            };

            await _customerRepository.AddAsync(newCustomer);
            return OperationResult<string>.Success("Customer created successfully");
    }
        }
}
