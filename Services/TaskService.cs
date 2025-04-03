using AutoMapper;
using RasDashboard.DTOs;
using RasDashboard.Interfaces;
using RasDashboard.Models;
using Task = System.Threading.Tasks.Task;

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


    public List<TaskDto> GetAllTasks()
    {
        var tasks = _taskRepository.GetAllTasks();
        return _mapper.Map<List<TaskDto>>(tasks);
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
