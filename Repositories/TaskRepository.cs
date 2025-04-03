using RasDashboard.Areas.Identity.Data;
using RasDashboard.DTOs;
using RasDashboard.Interfaces;
using RasDashboard.Models;
using Task = RasDashboard.Models.Task;

namespace RasDashboard.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly RasDashboardContext _dbContext;

    public TaskRepository(RasDashboardContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<Task> GetAllTasks()
    {
       return _dbContext.Tasks.ToList();
    }

    public Task<TaskItem> CreateTask(TaskItem taskItem)
    {
        throw new NotImplementedException();
    }

    public Task<TaskItem> UpdateTask(TaskItem taskItem)
    {
        throw new NotImplementedException();
    }

    public Task<TaskItem> DeleteTask(int id)
    {
        throw new NotImplementedException();
    }
}