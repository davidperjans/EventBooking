using Application.Interfaces;
using Domain.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(AppDbContext context) : base(context) { }
        public async Task<OperationResult<List<Ticket>>> GetTicketsWithEventsAsync()
        {
            try
            {
                var tickets = await _context.Tickets.Include(ticket => ticket.Event).ToListAsync();

                return OperationResult<List<Ticket>>.Success(tickets);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Ticket>>.Failure("An error occurred while retrieving tickets.");
            }
        }
    }
}
