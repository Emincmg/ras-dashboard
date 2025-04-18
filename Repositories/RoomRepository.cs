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
    
    /// <inheritdoc />
    public Room AddRoom(Room room)
    {
        _context.Rooms.Add(room);
        _context.SaveChanges();
        return room;
    }
    
    /// <inheritdoc />
    public async Task<Room> AddRoomAsync(Room room)
    {
        await _context.Rooms.AddAsync(room);
        await _context.SaveChangesAsync();
        return room;
    }
    
    /// <inheritdoc />
    public async Task<List<Room>> GetAllRoomsAsync()
    {
        return await _context.Rooms.ToListAsync();
    }

    /// <inheritdoc />
    public Room? GetRoomById(int id)
    {
        return _context.Rooms.FirstOrDefault(x => x.Id == id);
    }
    
    /// <inheritdoc />
    public async Task<Room?> GetRoomByIdAsync(int id)
    {
        return await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    /// <inheritdoc />
    public List<Room> GetAllRooms()
    {
        return _context.Rooms.ToList();
    }
}