using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RasDashboard.Areas.Identity.Data;
using RasDashboard.DTOs;
using RasDashboard.Interfaces;
using RasDashboard.Models;

namespace RasDashboard.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly RasDashboardContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public TaskRepository(RasDashboardContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;

    }
    /// <summary>
    /// Gets all the employee tasks from the database.
    /// </summary>
    /// <returns></returns>
    public List<EmployeeTask> GetAllTasks()
    {
       return _dbContext.EmployeeTasks.ToList();
    }

    /// <summary>
    /// Creates a new task item in the database.
    /// </summary>
    /// <param name="taskItem">The task item to be added to the database.</param>
    /// <returns>
    /// A Task containing the created TaskItem object after it has been added to the database.
    /// </returns>
    public Task<TaskItem> CreateTask(TaskItem taskItem)
    {
        _dbContext.TaskItems.Add(taskItem);
        _dbContext.SaveChanges();
        return Task.FromResult(taskItem);
    }

    /// <summary>
    /// Gets the current task for the logged-in employee.
    /// </summary>
    /// <returns></returns>
    public async Task<TaskItem?> GetCurrentTaskAsync()
    {
        var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return null; 
        }

        return await _dbContext.TaskItems
            .Where(t => t.Employee !=null && t.Employee.Id == userId && t.IsCurrent)
            .FirstOrDefaultAsync();
    }
    
    /// <summary>
    /// Asynchronously creates a new task item in the database.
    /// </summary>
    /// <param name="taskItem">The task item to be added to the database.</param>
    /// <returns>
    /// A Task containing the created TaskItem object after it has been added to the database.
    /// </returns>
    public async Task<TaskItem> CreateTaskAsync(TaskItem taskItem)
    {
        await _dbContext.TaskItems.AddAsync(taskItem);
        await _dbContext.SaveChangesAsync();
        return await Task.FromResult(taskItem);
    }
    
    /// <summary>
    /// Updates an existing task item in the database.
    /// </summary>
    /// <param name="taskItem"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TaskItem> UpdateTask(TaskItem taskItem)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a task from the database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TaskItem> DeleteTask(int id)
    {
        throw new NotImplementedException();
    }
}