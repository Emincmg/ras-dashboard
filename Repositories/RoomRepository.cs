using Microsoft.EntityFrameworkCore;
using RasDashboard.Areas.Identity.Data;
using RasDashboard.Interfaces;
using RasDashboard.Models;
using Task = System.Threading.Tasks.Task;

namespace RasDashboard.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly RasDashboardContext _context;

    public RoomRepository(RasDashboardContext context)
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