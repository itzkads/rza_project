using Microsoft.EntityFrameworkCore;
using rza_project.Models;

namespace rza_project.Services
{
    public class TicketbookingService
    {
        private readonly TlS2302758RzaContext _context;
        public TicketbookingService(TlS2302758RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Ticket>> GetTicketsAsync()
        {
            return await _context.Tickets.ToListAsync();
        }
        public async Task AddTicketAsync(Ticket newTicket)
        {
            await _context.Tickets.AddAsync(newTicket);
            await _context.SaveChangesAsync();
        }
    }
}