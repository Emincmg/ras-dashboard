namespace RasDashboard.DTOs;

public class TaskDto
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
    public required string Name { get; set; } 
    public required string Description { get; set; } 
    public List<TaskItemDto> TaskItems { get; set; } = new List<TaskItemDto>();
}