using RasDashboard.DTOs.Rooms;

namespace RasDashboard.Interfaces;

public interface IRoomsService
{
    /// <summary>
    /// Gets all rooms from the database.
    /// </summary>
    /// <returns>List of RoomDto that has been gotten from db.</returns>
    public async Task<List<RoomDto>> GetAllRoomsAsync() { return await Task.FromResult(new List<RoomDto>()); }

        
    /// <summary>
    /// Gets all rooms from the database.
    /// </summary>
    /// <returns></returns>
    public List<RoomDto> GetAllRooms();
    
    /// <summary>
    /// Get a room by its ID. Null if not found.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public RoomDto GetRoomById(int id){ return new RoomDto(); }

    /// <summary>
    /// Get a room by its ID. Null if not found.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<RoomDto> GetRoomByIdAsync(int id){ return await Task.FromResult(new RoomDto()); }
}