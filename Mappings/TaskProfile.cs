using AutoMapper;
using RasDashboard.DTOs;
using RasDashboard.Models;

namespace RasDashboard.Mappings;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<EmployeeTask, TaskDto>().ReverseMap();
    }
}