using AutoMapper;
using RasDashboard.DTOs;
using RasDashboard.Models;

namespace RasDashboard.Mappings;

public class EmployeeProfile: Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeDto, Employee>()
            .ForMember(dest => dest.TaskItems, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<Employee, EmployeeDto>()
     .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
         src.TaskItems
             .FirstOrDefault(t => t.IsCurrent == true && t.IsCompleted == false) != null ? "Occupied" : "Free"))
     .ForMember(dest => dest.ActiveTaskName, opt =>
         opt.MapFrom(src =>
             src.TaskItems
                 .FirstOrDefault(t => t.IsCurrent == true && t.IsCompleted == false)
                 .Rooms.FirstOrDefault().Name
         ));
    }
}       
