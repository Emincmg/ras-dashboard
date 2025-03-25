using RhsDashboard.DTOs;
using RhsDashboard.Models;

namespace RhsDashboard.Interfaces;

public interface ITaskRepository
{
    public Task<List<TaskItem>> GetAllTasks();
    public Task<TaskItemDto> CreateTask(TaskItem taskItem);
    public Task<TaskItemDto> UpdateTask(TaskItem taskItem);
    public Task<TaskItemDto> DeleteTask(int id);
}