using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerCQRS.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<OperationResult<string>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public CreateCustomerCommand(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }
}
