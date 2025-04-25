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
        taskItem.Tasks =  _dbContext.EmployeeTasks
            .Where(et => taskItem.Tasks.Select(t => t.Id).Contains(et.Id))
            .ToList();

        taskItem.Rooms =  _dbContext.Rooms
            .Where(r => taskItem.Rooms.Select(t => t.Id).Contains(r.Id))
            .ToList();

        _dbContext.TaskItems.Add(taskItem);
        _dbContext.SaveChanges();
        return Task.FromResult(taskItem);
    }

    /// <inheritdoc />
    public TaskItem? GetCurrentTask(string employeeId)
    {
        return _dbContext.TaskItems
            .Include(t => t.Tasks)
            .Include(t => t.Rooms)
            .FirstOrDefault(t => t.Employee != null && t.EmployeeId == employeeId && t.IsCurrent);
    }

    /// <inheritdoc />
    public async Task<TaskItem>? GetCurrentTaskAsync(string employeeId)
    {
        var currentTask = await _dbContext.TaskItems
            .Include(t => t.Tasks)
            .Include(t => t.Rooms)
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

        if (existingTask.Tasks is { Count: > 0 })
        {
            var taskIds = existingTask.Tasks.Select(t => t.Id).ToList();
    
            // Track edilen entity'leri çek
            var existingTasks = _dbContext.EmployeeTasks
                .Where(t => taskIds.Contains(t.Id))
                .ToList();

            // Mevcut collection'ı temizle ve yeniden ekle
            existingTask.Tasks.Clear();
            foreach (var task in existingTasks)
            {
                existingTask.Tasks.Add(task);
            }
        }
        

        if (taskItem.Rooms is { Count: > 0 })
        {
            var roomIds = taskItem.Rooms.Select(r => r.Id).ToList();
    
            // Track edilen entity'leri çek
            var existingRooms = _dbContext.Rooms
                .Where(r => roomIds.Contains(r.Id))
                .ToList();

            // Mevcut collection'ı temizle ve yeniden ekle
            taskItem.Rooms.Clear();
            foreach (var room in existingRooms)
            {
                taskItem.Rooms.Add(room);
            }
        }

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