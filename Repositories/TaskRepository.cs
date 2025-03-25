using RhsDashboard.Areas.Identity.Data;
using RhsDashboard.DTOs;
using RhsDashboard.Interfaces;
using RhsDashboard.Models;

namespace RhsDashboard.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly RhsDashboardContext _dbContext;

    public TaskRepository(RhsDashboardContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<List<TaskItem>> GetAllTasks()
    {
        throw new NotImplementedException();
    }

    public Task<TaskItemDto> CreateTask(TaskItem taskItem)
    {
        throw new NotImplementedException();
    }

    public Task<TaskItemDto> UpdateTask(TaskItem taskItem)
    {
        throw new NotImplementedException();
    }

    public Task<TaskItemDto> DeleteTask(int id)
    {
        throw new NotImplementedException();
    }
}