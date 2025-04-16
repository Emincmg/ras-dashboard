using RasDashboard.Models;

namespace RasDashboard.DTOs;

public class TaskItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public bool IsCurrent { get; set; } = false;
    public DateTime DueDate { get; set; } = DateTime.Now;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<EmployeeTask>? Tasks { get; set; } 
    public List<Room>? Rooms { get; set; }
    public List<Employee>? Employees { get; set; }
}
