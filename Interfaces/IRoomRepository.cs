using RhsDashboard.DTOs.Rooms;
using RhsDashboard.Models;

namespace RhsDashboard.Interfaces;

public interface IRoomRepository
{
    Task<List<Room>> GetAllRoomsAsync();

    public List<Room> GetAllRooms();
}