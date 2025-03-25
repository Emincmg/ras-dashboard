using AutoMapper;
using RhsDashboard.DTOs;

namespace RhsDashboard.Models;

public class TaskItemProfile : Profile
{
    public TaskItemProfile()
    {
        CreateMap<TaskItem, TaskItemDto>().ReverseMap();
    }
    
}