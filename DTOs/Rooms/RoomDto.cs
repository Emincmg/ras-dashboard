using System.ComponentModel.DataAnnotations;

namespace RasDashboard.DTOs.Rooms;

public class RoomDto
{
    public int Id { get; set; } = 0;
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;
    [MaxLength(200)]
    public string Street { get; set; } = string.Empty;
}