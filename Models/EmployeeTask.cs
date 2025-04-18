using System.ComponentModel.DataAnnotations;

namespace RasDashboard.Models;

public class EmployeeTask : Entity
{
    [MaxLength(50)]
    public string? Name { get; set; } 
    [MaxLength(255)]
    public string? Description { get; set; } 
    public List<TaskItem>? TaskItems { get; set; }
}