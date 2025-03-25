using System.ComponentModel.DataAnnotations;

namespace RhsDashboard.Models;

public class TaskItem : Entity<Guid>
{
    [Required, MaxLength(255)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(1000)]
    public string? Description { get; set; }

    public bool IsCompleted { get; set; } = false;

    public DateTime DueDate { get; set; } = DateTime.Now;
    public DateTime StartTime { get; set; } = DateTime.Now;
    public DateTime EndTime { get; set; }
    public List<Task> Tasks { get; set; } = new List<Task>();
    public List<Room> Rooms { get; set; } = new List<Room>();
    
}