using Microsoft.EntityFrameworkCore;
using RasDashboard.Areas.Identity.Data;
using RasDashboard.Interfaces;
using RasDashboard.Models;

namespace RasDashboard.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly RasDashboardContext _dbContext;

    public TaskRepository(RasDashboardContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public List<EmployeeTask> GetAllTasks()
    {
        return _dbContext.EmployeeTasks.ToList();
    }

    /// <inheritdoc />
    public Task<TaskItem> CreateTask(TaskItem taskItem)
    {
        _dbContext.TaskItems.Add(taskItem);
        _dbContext.SaveChanges();
        return Task.FromResult(taskItem);
    }

    /// <inheritdoc />
    public TaskItem? GetCurrentTask(string employeeId)
    {
        return _dbContext.TaskItems
            .FirstOrDefault(t => t.Employee != null && t.EmployeeId == employeeId && t.IsCurrent);
    }

    /// <inheritdoc />
    public async Task<TaskItem>? GetCurrentTaskAsync(string employeeId)
    {
        var currentTask = await _dbContext.TaskItems
            .Where(t => t.Employee != null && t.EmployeeId == employeeId && t.IsCurrent)
            .FirstOrDefaultAsync();
        if (currentTask == null)
        {
            throw new NullReferenceException("Task item not found by repository.");
        }

        return currentTask;
    }

    /// <inheritdoc />
    public TaskItem? GetTaskById(Guid id)
    {
        return _dbContext.TaskItems.Find(id);
    }

    /// <inheritdoc />
    public async Task<TaskItem?> GetTaskByIdAsync(Guid id)
    {
        return await _dbContext.TaskItems.FindAsync(id);
    }

    /// <inheritdoc />
    public async Task<TaskItem> CreateTaskAsync(TaskItem taskItem)
    {
        await _dbContext.TaskItems.AddAsync(taskItem);
        await _dbContext.SaveChangesAsync();
        return await Task.FromResult(taskItem);
    }

    /// <inheritdoc />
    public Task<TaskItem> UpdateTask(TaskItem taskItem)
    {
        var existingTask = _dbContext.TaskItems
            .Include(t => t.Tasks)
            .Include(t => t.Rooms)
            .FirstOrDefault(t => t.Id == taskItem.Id);

        if (existingTask == null)
        {
            throw new InvalidOperationException("Task not found");
        }
        
        existingTask.Tasks = taskItem.Tasks;
        existingTask.Rooms = taskItem.Rooms;
        existingTask.UpdatedDate = DateTime.Now;

        _dbContext.SaveChanges();

        return Task.FromResult(existingTask);
    }

    /// <inheritdoc />
    public Task<TaskItem> DeleteTask(int id)
    {
        throw new NotImplementedException();
    }
}