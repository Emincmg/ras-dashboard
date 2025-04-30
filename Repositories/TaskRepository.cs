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
            .FirstOrDefault(t => t.Employee != null && t.EmployeeId == employeeId && t.IsCurrent == true);
    }

    /// <inheritdoc />
    public async Task<TaskItem>? GetCurrentTaskAsync(string employeeId)
    {
        var currentTask = await _dbContext.TaskItems
            .Include(t => t.Tasks)
            .Include(t => t.Rooms)
            .Where(t => t.Employee != null && t.EmployeeId == employeeId && t.IsCurrent == true)
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
        return _dbContext.TaskItems
            .Include(t => t.Tasks)
            .Include(t => t.Rooms)
            .FirstOrDefault(t => t.Id == id);
    }

    /// <inheritdoc />
    public async Task<TaskItem?> GetTaskByIdAsync(Guid id)
    {
        return await _dbContext.TaskItems
            .Include(t => t.Tasks)
            .Include(t => t.Rooms)
            .FirstOrDefaultAsync(t => t.Id == id);
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
        taskItem.UpdatedDate = DateTime.Now;

        _dbContext.SaveChanges();

        return Task.FromResult(taskItem);
    }

    /// <inheritdoc />
    public Task<TaskItem> DeleteTask(int id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<List<EmployeeTask>> GetEmployeeTasksByIdsAsync(List<Guid> ids)
    {
        return await _dbContext.EmployeeTasks
            .Where(t => ids.Contains(t.Id))
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<List<Room>> GetRoomsByIdsAsync(List<int> ids)
    {
        return await _dbContext.Rooms
            .Where(r => ids.Contains(r.Id))
            .ToListAsync();
    }
    
    /// <inheritdoc />
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}