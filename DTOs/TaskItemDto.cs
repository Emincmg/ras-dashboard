using System.ComponentModel.DataAnnotations;
using RasDashboard.DTOs.Rooms;
using RasDashboard.Models;

namespace RasDashboard.DTOs;

public class TaskItemDto
{
    public Guid Id { get; set; } = Guid.Empty;
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } = false;
    public bool IsCurrent { get; set; } = false;
    public int RoomId { get; set; } = 0;
    public DateTime DueDate { get; set; } = DateTime.Now;
    public DateTime StartTime { get; set; } = DateTime.Now;
    public DateTime EndTime { get; set; } = DateTime.Now;
    public List<TaskDto> Tasks { get; set; } = [];
    public List<RoomDto> Rooms { get; set; } = [];
    public List<EmployeeDto> Employees { get; set; } = [];
    public List<int> TaskIds { get; set; } = [];
    public List<IFormFile> MediaFiles { get; set; } = [];
}
