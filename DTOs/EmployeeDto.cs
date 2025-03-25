namespace RhsDashboard.DTOs;

public class EmployeeDto
{
    public required string Id { get; set; }
    public string? Name { get; set; }
    public string? CurrentLocation { get; set; }
    public string? AssignedLocation { get; set; }
    public DateTime CheckInTime { get; set; }
    public DateTime CheckOutTime { get; set; }
    public int LeaveStatus { get; set; }
    public required string Position { get; set; }
    public required string Department { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
}