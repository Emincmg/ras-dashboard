using RhsDashboard.Models;
using Task = System.Threading.Tasks.Task;

namespace RhsDashboard.DTOs;

public class TaskItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public DateTime DueDate { get; set; } = DateTime.Now;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<Task> Tasks { get; set; } = new List<Task>();
    public List<Room> Rooms { get; set; } = new List<Room>();
    public List<Employee> Employees { get; set; } = new List<Employee>();
}
