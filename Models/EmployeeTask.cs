using System.ComponentModel.DataAnnotations;

namespace RasDashboard.Models;

public class EmployeeTask : Entity
{
    [Required, MaxLength(50)]
    public required string Name { get; set; } 
    [Required, MaxLength(255)]
    public required string Description { get; set; } 
    public List<TaskItem>? TaskItems { get; set; }
}