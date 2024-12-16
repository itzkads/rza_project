
using Microsoft.EntityFrameworkCore;
using rza_project.Models;

namespace RZA_sly.Services
{
    public class RoomService
    {
        private readonly TlS2302758RzaContext _context;
        public RoomService(TlS2302758RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }
        public async Task<Room> GetRoomAsync(int roomNumber)
        {
            return await _context.Rooms.FirstAsync(r => r.RoomCapacity == roomNumber);
        }
    }
}