using RasDashboard.DTOs.Rooms;
using RasDashboard.Models;

namespace RasDashboard.Interfaces;

public interface IRoomRepository
{
    Task<List<Room>> GetAllRoomsAsync();

    public List<Room> GetAllRooms();
}