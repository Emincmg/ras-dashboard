using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RasDashboard.Models;

public class Room
{
    [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    [Required,MaxLength(100)]
    public required string Name { get; set; }
    [Required, MaxLength(50)]
    public required string City { get; set; }
    [Required, MaxLength(200)]
    public required string Street { get; set; }    
    public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
    public List<Employee> Employees { get; set; } = new List<Employee>();
}