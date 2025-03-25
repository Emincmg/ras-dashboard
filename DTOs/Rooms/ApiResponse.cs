namespace RhsDashboard.DTOs.Rooms;

public class ApiResponse
{
    public required string Env { get; set; }
    public bool Success { get; set; }
    public required List<RoomDto> Listings { get; set; }
}