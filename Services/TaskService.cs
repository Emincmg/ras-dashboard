using AutoMapper;
using RhsDashboard.DTOs;
using RhsDashboard.Interfaces;
using RhsDashboard.Models;
using Task = System.Threading.Tasks.Task;

namespace RhsDashboard.Services;

public class TaskService : ITaskService
{
    private readonly IMapper _mapper;
    private readonly ITaskRepository _taskRepository;
    
    public TaskService(IMapper mapper, ITaskRepository taskRepository)
    {
        _mapper = mapper;
        _taskRepository = taskRepository;
    }


    public Task<List<TaskItemDto>> GetAllTasks()
    {
        throw new NotImplementedException();
    }

    public Task<TaskItemDto> CreateTask(TaskItemDto taskItemDto)
    {
        var taskItem = _mapper.Map<TaskItem>(taskItemDto);
        _taskRepository.CreateTask(taskItem);
        
        return Task.FromResult(taskItemDto);
    }

    public Task<TaskItemDto> UpdateTask(TaskItemDto taskItemDto)
    {
        throw new NotImplementedException();
    }

    public Task<TaskItemDto> DeleteTask(int id)
    {
        throw new NotImplementedException();
    }
}