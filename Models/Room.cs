using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RasDashboard.Models;

public class Room
{
    [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    [Required,MaxLength(100)]
    public string? Name { get; set; }
    [Required, MaxLength(50)]
    public string? City { get; set; }
    [Required, MaxLength(200)]
    public string? Street { get; set; }    
    public List<TaskItem> TaskItems { get; set; } = [];
    public List<Employee> Employees { get; set; } = [];
}