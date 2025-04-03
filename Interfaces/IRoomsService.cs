using RasDashboard.DTOs.Rooms;

namespace RasDashboard.Interfaces;

public interface IRoomsService
{
    public async Task<List<RoomDto>> GetAllRoomsAsync() { return await Task.FromResult(new List<RoomDto>()); }

    public List<RoomDto> GetAllRooms();

    public async void ImportRooms(){}
}