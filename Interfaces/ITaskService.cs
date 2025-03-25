using RhsDashboard.DTOs;

namespace RhsDashboard.Interfaces;

public interface ITaskService
{
    public Task<List<TaskItemDto>> GetAllTasks();
    public Task<TaskItemDto> CreateTask(TaskItemDto taskItemDto);
    public Task<TaskItemDto> UpdateTask(TaskItemDto taskItemDto);
    public Task<TaskItemDto> DeleteTask(int id);
}