using Microsoft.EntityFrameworkCore;
using RhsDashboard.Areas.Identity.Data;
using RhsDashboard.Interfaces;
using RhsDashboard.Models;
using Task = System.Threading.Tasks.Task;

namespace RhsDashboard.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly RhsDashboardContext _context;

    public RoomRepository(RhsDashboardContext context)
    {
        _context = context;
    }

    public async Task<List<Room>> GetAllRoomsAsync()
    {
        return await _context.Rooms.ToListAsync();
    }

    public List<Room> GetAllRooms()
    {
        return _context.Rooms.ToList();
    }
}