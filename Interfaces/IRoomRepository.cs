using RasDashboard.DTOs.Rooms;
using RasDashboard.Models;

namespace RasDashboard.Interfaces;

public interface IRoomRepository
{
    /// <summary>
    /// Fetches all rooms from the database.
    /// </summary>
    /// <returns></returns>
    Task<List<Room>> GetAllRoomsAsync();

    /// <summary>
    /// Fetches all rooms from the database.
    /// </summary>
    /// <returns></returns>
    List<Room> GetAllRooms();
    
    
    /// <summary>
    /// Get a room by its ID. Null if not found.
    /// </summary>
    /// <param name="id">ID of the room that will be fetched.</param>
    /// <returns>Room|Null whether its found or not.</returns>
    Room? GetRoomById(int id);
    
    /// <summary>
    /// Get room by its ID. Null if not found.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Room|Null whether its found or not.</returns>
    Task<Room?> GetRoomByIdAsync(int id);
    
    /// <summary>
    /// Adds a new room to the database asynchronously.
    /// </summary>
    /// <param name="room">Room instance that will be added</param>
    /// <returns></returns>
    Task<Room> AddRoomAsync(Room room);
    
    /// <summary>
    /// Adds a new room to the database.
    /// </summary>
    /// <param name="room"></param>
    /// <returns></returns>
    Room AddRoom(Room room);
}