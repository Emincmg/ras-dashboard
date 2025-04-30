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
        src.TaskItems.Any(t => t.IsCurrent == true && t.IsCompleted == false) ? "Occupied" : "Free"))
    .ForMember(dest => dest.ActiveTaskName, opt => opt.Ignore())
    .ForMember(dest => dest.TooltipTaskTitles, opt => opt.Ignore())
    .AfterMap((src, dest) =>
    {
        var activeTask = src.TaskItems.FirstOrDefault(t => t.IsCurrent == true && t.IsCompleted == false);

        if (activeTask == null)
        {
            dest.TooltipTaskTitles = "No Active Task";
        }
        else
        {
            dest.ActiveTaskName = activeTask.Rooms.FirstOrDefault()?.Name ?? "No Room";

            dest.TooltipTaskTitles = (activeTask.Tasks != null && activeTask.Tasks.Any())
                ? string.Join(", ", activeTask.Tasks.Select(t => t.Name.Replace("\"", "'")))
                : "No Tasks";
        }
    });

    }
}       
