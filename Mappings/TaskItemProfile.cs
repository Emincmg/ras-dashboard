using AutoMapper;
using RasDashboard.DTOs;
using RasDashboard.Models;

namespace RasDashboard.Mappings;

public class TaskItemProfile : Profile
{
    public TaskItemProfile()
    {
        CreateMap<TaskItem, TaskItemDto>().ReverseMap();
    }
    
}