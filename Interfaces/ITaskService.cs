using RasDashboard.DTOs;

namespace RasDashboard.Interfaces;

public interface ITaskService
{
    public List<TaskDto> GetAllTasks();
    public Task<TaskItemDto> CreateTask(TaskItemDto taskItemDto);
    public Task<TaskItemDto> UpdateTask(TaskItemDto taskItemDto);
    public Task<TaskItemDto> DeleteTask(int id);
}