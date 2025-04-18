using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RasDashboard.DTOs.Rooms;
using RasDashboard.Models;

namespace RasDashboard.DTOs;

public class TaskItemDto
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } = false;
    public bool IsCurrent { get; set; } = false;
    public DateTime DueDate { get; set; } = DateTime.Now;
    public DateTime StartTime { get; set; } = DateTime.Now;
    public DateTime EndTime { get; set; } = DateTime.Now;
    [ForeignKey("EmployeeId")]
    public string? EmployeeId { get; set; }
    public List<Guid> TaskIds { get; set; } = new();
    public List<int> RoomIds { get; set; } = new();
    
    public List<IFormFile> MediaFiles { get; set; } = new();
}

