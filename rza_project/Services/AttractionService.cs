using Microsoft.EntityFrameworkCore;
using rza_project.Models;


namespace rza_project.Services
{
    public class AttractionService
    {
        private readonly TlS2302758RzaContext _context;
        public AttractionService(TlS2302758RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Attraction>> GetAttractionsAsync()
        {
            return await _context.Attractions.ToListAsync();
        }
    }
}
