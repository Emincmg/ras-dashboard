using AutoMapper;
using RasDashboard.DTOs;
using Task = RasDashboard.Models.Task;

namespace RasDashboard.Mappings;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<Task, TaskDto>().ReverseMap();
    }
}