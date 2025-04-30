using RasDashboard.Models;

namespace RasDashboard.Interfaces;

public interface ITaskRepository
{
    /// <summary>
    /// Gets all the employee tasks from the database.
    /// </summary>
    /// <returns></returns>
    public List<EmployeeTask> GetAllTasks();

    /// <summary>
    /// Creates a new task item in the database.
    /// </summary>
    /// <param name="taskItem">The task item to be added to the database.</param>
    /// <returns>
    /// A Task containing the created TaskItem object after it has been added to the database.
    /// </returns>
    public Task<TaskItem> CreateTask(TaskItem taskItem);

    /// <summary>
    /// Asynchronously creates a new task item in the database.
    /// </summary>
    /// <param name="taskItem">The task item to be added to the database.</param>
    /// <returns>
    /// A Task containing the created TaskItem object after it has been added to the database.
    /// </returns>
    public Task<TaskItem> CreateTaskAsync(TaskItem taskItem);

    /// <summary>
    /// Updates an existing task item in the database.
    /// </summary>
    /// <param name="taskItem"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TaskItem> UpdateTask(TaskItem taskItem);

    /// <summary>
    /// Deletes a task from the database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TaskItem> DeleteTask(int id);

    /// <summary>
    /// Gets the current task for the logged-in employee.
    /// </summary>
    /// <param name="employeeId"> ID of the employee.</param>
    /// <returns></returns>
    public TaskItem? GetCurrentTask(string employeeId);

    /// <summary>
    /// Gets the current task for the logged-in employee.
    /// </summary>
    /// <param name="employeeId"> ID of the employee that its task will be retrieved. </param>
    /// <returns></returns>
    public Task<TaskItem>? GetCurrentTaskAsync(string employeeId);

    /// <summary>
    /// Return a task item by its ID.
    /// </summary>
    /// <param name="id">ID of the task item</param>
    /// <returns></returns>
    public TaskItem? GetTaskById(Guid id);

    /// <summary>
    /// Return a task item by its ID asynchronously.
    /// </summary>
    /// <param name="id">ID of the task item</param>
    /// <returns></returns>
    public Task<TaskItem?> GetTaskByIdAsync(Guid id);


    /// <summary>
    /// Get all employee tasks from the database.
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public Task<List<EmployeeTask>> GetEmployeeTasksByIdsAsync(List<Guid> ids);

    /// <summary>
    /// Get all rooms from the database.
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public Task<List<Room>> GetRoomsByIdsAsync(List<int> ids);


    /// <summary>
    /// Save changes to the database.
    /// </summary>
    /// <returns></returns>
    public async Task SaveChangesAsync() { }
}