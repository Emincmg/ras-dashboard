using RasDashboard.DTOs;

namespace RasDashboard.Interfaces;

public interface ITaskService
{
    /// <summary>
    /// Gets all the tasks from the database.
    /// </summary>
    /// <returns></returns>
    public List<TaskDto> GetAllTasks();
    
    /// <summary>
    /// Creates a task item in the database. Endpoint used by employees when they create a task.
    /// </summary>
    /// <param name="taskItemDto">Task item DTO instance that will be converted and will be saved to the database.</param>
    /// <returns></returns>
    public Task<TaskItemDto> CreateTask(TaskItemDto taskItemDto);
    
    /// <summary>
    /// Updates a task in the database.
    /// </summary>
    /// <param name="taskItemDto">Task item DTO instance that will be converted and will be updated.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TaskItemDto> UpdateTask(TaskItemDto taskItemDto);
    
    /// <summary>
    /// Delete a task item from database. Not to be confused with deleting a task itself, it refers to a task item created
    /// by an employee.
    /// </summary>
    /// <param name="id">ID of the task item that will be removed.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TaskItemDto> DeleteTask(int id);
    
    /// <summary>
    /// Gets current task for the logged-in employee.
    /// </summary>
    /// <param name="employeeId"> ID of the employee that their id sent.</param>
    /// <returns>Null if no current task, Current task if not null.</returns>
    public TaskItemDto? GetCurrentTask(string employeeId);
    
    /// <summary>
    /// Gets current task for the logged-in employee asynchronously.
    /// </summary>
    /// <param name="employeeId"> ID of the employee that their id sent</param>
    /// <returns></returns>
    public async Task<TaskItemDto>? GetCurrentTaskAsync(string employeeId){ return await Task.FromResult(new TaskItemDto()); }
    
    /// <summary>
    /// Return a task item by its ID.
    /// </summary>
    /// <param name="id">ID of the task</param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException">Thrown if no task item found by given ID</exception>
    public TaskDto GetTaskById(Guid id);
    
    /// <summary>
    /// Return a task item by its ID asynchronously.
    /// </summary>
    /// <param name="id">ID Of the task</param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public Task<TaskDto> GetTaskByIdAsync(Guid id){ return Task.FromResult(new TaskDto()); }
}