using System.ComponentModel.DataAnnotations;

namespace RasDashboard.DTOs;

public class TaskDto
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;
    public List<TaskItemDto> TaskItems { get; set; } = [];
}