using AutoMapper;
using RasDashboard.DTOs;
using RasDashboard.Interfaces;
using RasDashboard.Models;

namespace RasDashboard.Services;

public class TaskService : ITaskService
{
    private readonly IMapper _mapper;
    private readonly ITaskRepository _taskRepository;
    
    public TaskService(IMapper mapper, ITaskRepository taskRepository)
    {
        _mapper = mapper;
        _taskRepository = taskRepository;
    }

    /// <summary>
    /// Gets all the tasks from the database.
    /// </summary>
    /// <returns></returns>
    public List<TaskDto> GetAllTasks()
    {
        var tasks = _taskRepository.GetAllTasks();
        return _mapper.Map<List<TaskDto>>(tasks);
    }

    /// <summary>
    /// Gets current task for the logged-in employee.
    /// </summary>
    /// <returns></returns>
    public TaskDto GetCurrentTask()
    {
        var task = _taskRepository.GetCurrentTaskAsync();
        return _mapper.Map<TaskDto>(task);
    }
    
    /// <summary>
    /// Creates a task item in the database. Endpoint used by employees when they create a task.
    /// </summary>
    /// <param name="taskItemDto">Task item DTO instance that will be converted and will be saved to the database.</param>
    /// <returns></returns>
    public Task<TaskItemDto> CreateTask(TaskItemDto taskItemDto)
    {
        var taskItem = _mapper.Map<TaskItem>(taskItemDto);
        _taskRepository.CreateTask(taskItem);
        
        return Task.FromResult(taskItemDto);
    }

    /// <summary>
    /// Updates a task in the database.
    /// </summary>
    /// <param name="taskItemDto">Task item DTO instance that will be converted and will be updated.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TaskItemDto> UpdateTask(TaskItemDto taskItemDto)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Delete a task item from database. Not to be confused with deleting a task itself, it refers to a task item created
    /// by an employee.
    /// </summary>
    /// <param name="id">ID of the task item that will be removed.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TaskItemDto> DeleteTask(int id)
    {
        throw new NotImplementedException();
    }
}
