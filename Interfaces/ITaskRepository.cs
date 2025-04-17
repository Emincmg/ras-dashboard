using RasDashboard.DTOs;
using RasDashboard.Models;

namespace RasDashboard.Interfaces;

public interface ITaskRepository
{
    public List<EmployeeTask> GetAllTasks();
    public Task<TaskItem> CreateTask(TaskItem taskItem);
    public Task<TaskItem> UpdateTask(TaskItem taskItem);
    public Task<TaskItem> DeleteTask(int id);
    public TaskItem? GetCurrentTask(string employeeId);
    public Task<TaskItem>? GetCurrentTaskAsync(string employeeId);
    public TaskItem? GetTaskById(Guid id);
    public Task<TaskItem?> GetTaskByIdAsync(Guid id);
}