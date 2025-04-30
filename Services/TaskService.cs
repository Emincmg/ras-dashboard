using AutoMapper;
using RasDashboard.DTOs;
using RasDashboard.Interfaces;
using RasDashboard.Models;
using RasDashboard.Repositories;

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
    public async Task<TaskItemDto> UpdateTask(TaskItemDto taskItemDto)
    {
        var existingTask = await _taskRepository.GetTaskByIdAsync(taskItemDto.Id);
        if (existingTask == null)
        {
            throw new Exception("Could not find the task to update.");
        }

        existingTask.Title = taskItemDto.Title;
        existingTask.Description = taskItemDto.Description;
        existingTask.EmployeeId = taskItemDto.EmployeeId;
        existingTask.IsCompleted = taskItemDto.IsCompleted;
        existingTask.IsCurrent = taskItemDto.IsCurrent;
        existingTask.DueDate = taskItemDto.DueDate;

        var tasks = await _taskRepository.GetEmployeeTasksByIdsAsync(taskItemDto.TaskIds);
        var rooms = await _taskRepository.GetRoomsByIdsAsync(taskItemDto.RoomIds);

        existingTask.Tasks.Clear();
        existingTask.Rooms.Clear();

        foreach (var task in tasks)
        {
            existingTask.Tasks.Add(task);
        }

        foreach (var room in rooms)
        {
            existingTask.Rooms.Add(room);
        }

        _taskRepository.UpdateTask(existingTask);

        return taskItemDto;
    }


    /// <inheritdoc />
    public Task<TaskItemDto> DeleteTask(int id)
    {
        throw new NotImplementedException();
    }
}