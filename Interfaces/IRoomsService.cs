using RasDashboard.DTOs.Rooms;

namespace RasDashboard.Interfaces;

public interface IRoomsService
{
    /// <summary>
    /// Gets all rooms from the database.
    /// </summary>
    /// <returns>List of RoomDto that has been gotten from db.</returns>
    Task<List<RoomDto>> GetAllRoomsAsync();

        
    /// <summary>
    /// Gets all rooms from the database.
    /// </summary>
    /// <returns></returns>
    List<RoomDto> GetAllRooms();
    
    /// <summary>
    /// Get a room by its ID. Null if not found.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    RoomDto GetRoomById(int id){ return new RoomDto(); }

    /// <summary>
    /// Get a room by its ID. Null if not found.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<RoomDto> GetRoomByIdAsync(int id);
}