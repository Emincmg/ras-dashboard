using System.ComponentModel.DataAnnotations;
using RasDashboard.DTOs;

namespace RasDashboard.Models;

public class TaskItem : Entity
{
    [Required, MaxLength(255)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(1000)]
    public string? Description { get; set; }

    public bool IsCompleted { get; set; } = false;
    public bool IsCurrent { get; set; } = false;
 
    public DateTime DueDate { get; set; } = DateTime.Now;
    public DateTime StartTime { get; set; } = DateTime.Now;
    public DateTime EndTime { get; set; }
    
    public List<EmployeeTask>? Tasks { get; set; } 
    public List<Room>? Rooms { get; set; }
    public Employee? Employee { get; set; }
}