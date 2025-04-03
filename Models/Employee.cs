using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RasDashboard.Models;

public class Employee : IdentityUser
{
    [Required, MaxLength(50)] public string? Name { get; set; }
    [MaxLength(50)] public string? CurrentLocation { get; set; }
    [MaxLength(50)] public string? AssignedLocation { get; set; }
    public DateTime CheckInTime { get; set; }
    public DateTime CheckOutTime { get; set; }
    public int LeaveStatus { get; set; }
    [MaxLength(50)] public string Position { get; set; } = string.Empty;
    [MaxLength(50)] public string Department { get; set; } = string.Empty;
    
    public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
}