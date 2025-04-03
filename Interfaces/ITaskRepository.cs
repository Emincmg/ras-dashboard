using RasDashboard.DTOs;
using RasDashboard.Models;
using Task = RasDashboard.Models.Task;

namespace RasDashboard.Interfaces;

public interface ITaskRepository
{
    public List<Task> GetAllTasks();
    public Task<TaskItem> CreateTask(TaskItem taskItem);
    public Task<TaskItem> UpdateTask(TaskItem taskItem);
    public Task<TaskItem> DeleteTask(int id);
}