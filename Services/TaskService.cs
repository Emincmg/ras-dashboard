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

    /// <inheritdoc />
    public List<TaskDto> GetAllTasks()
    {
        var tasks = _taskRepository.GetAllTasks();
        return _mapper.Map<List<TaskDto>>(tasks);
    }

    /// <inheritdoc />
    public TaskItemDto? GetCurrentTask(string employeeId)
    {
        var task = _taskRepository.GetCurrentTask(employeeId);
  
        return task == null ? null : _mapper.Map<TaskItemDto>(task);
    }

    /// <inheritdoc />
    public Task<TaskItemDto>? GetCurrentTaskAsync(string employeeId)
    {
        var task = _taskRepository.GetCurrentTaskAsync(employeeId);
        if (task == null)
        {
            return null;
        }

        return Task.FromResult(_mapper.Map<TaskItemDto>(task));
    }

    /// <inheritdoc />
    public TaskDto GetTaskById(Guid id)
    {
        var task = _taskRepository.GetTaskById(id);
        if (task == null)
        {
            throw new NullReferenceException("Task not found");
        }

        return _mapper.Map<TaskDto>(task);
    }

    /// <inheritdoc />
    public Task<TaskDto> GetTaskByIdAsync(Guid id)
    {
        var task = _taskRepository.GetTaskByIdAsync(id);
        if (task == null)
        {
            throw new NullReferenceException("Task not found");
        }

        return Task.FromResult(_mapper.Map<TaskDto>(task));
    }

    /// <inheritdoc />
    public Task<TaskItemDto> CreateTask(TaskItemDto taskItemDto)
    {
        var taskItem = _mapper.Map<TaskItem>(taskItemDto);
        
        _taskRepository.CreateTask(taskItem);

        return Task.FromResult(taskItemDto);
    }

    /// <inheritdoc />
    public Task<TaskItemDto> UpdateTask(TaskItemDto taskItemDto)
    {
         var taskItem = _taskRepository.GetTaskById(taskItemDto.Id);
         if (taskItem == null)
         {
             throw new NullReferenceException("Task not found");
         }
         taskItem = _mapper.Map(taskItemDto, taskItem);
         _taskRepository.UpdateTask(taskItem);
        
        return Task.FromResult(taskItemDto);
    }

    /// <inheritdoc />
    public Task<TaskItemDto> DeleteTask(int id)
    {
        throw new NotImplementedException();
    }
}