namespace RasDashboard.DTOs;

public class EmployeeDto
{
    public required string Id { get; set; }
    public string? Name { get; set; }
    public string? CurrentLocation { get; set; }
    public string? AssignedLocation { get; set; }
    public DateTime CheckInTime { get; set; }
    public DateTime CheckOutTime { get; set; }
    public int LeaveStatus { get; set; }
    public string? Position { get; set; }
    public string? Department { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public  List<TaskItemDto>? TaskItems { get; set; }
    public string? ActiveTaskName { get; set; }
    public string? Status { get; set; }
    public string? TooltipTaskTitles { get; set; }

}