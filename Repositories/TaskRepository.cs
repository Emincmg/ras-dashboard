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
    /// <param name="employeeId"> ID of the employee.</param>
    /// <returns></returns>
    public TaskItem? GetCurrentTask(string employeeId)
    {
        return _dbContext.TaskItems
            .FirstOrDefault(t => t.Employee !=null && t.Employee.Id == employeeId && t.IsCurrent);
    }
    
    /// <summary>
    /// Gets the current task for the logged-in employee.
    /// </summary>
    /// <param name="employeeId"> ID of the employee that its task will be retrieved. </param>
    /// <returns></returns>
    public async Task<TaskItem>? GetCurrentTaskAsync(string employeeId)
    {
        var currentTask =  await _dbContext.TaskItems
            .Where(t => t.Employee !=null && t.Employee.Id == employeeId && t.IsCurrent)
            .FirstOrDefaultAsync();
        if (currentTask == null)
        {
            throw new NullReferenceException("Task item not found");
        }

        return currentTask;
    }

    /// <summary>
    /// Return a task item by its ID.
    /// </summary>
    /// <param name="id">ID of the task item</param>
    /// <returns></returns>
    public TaskItem? GetTaskById(Guid id)
    {
        return _dbContext.TaskItems.Find(id);
    }

    /// <summary>
    /// Return a task item by its ID asynchronously.
    /// </summary>
    /// <param name="id">ID of the task item</param>
    /// <returns></returns>
    public async Task<TaskItem?> GetTaskByIdAsync(Guid id)
    {
       return await _dbContext.TaskItems.FindAsync(id);
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