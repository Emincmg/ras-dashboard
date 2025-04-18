using AutoMapper;
using RasDashboard.DTOs;
using RasDashboard.Models;

namespace RasDashboard.Mappings;

public class EmployeeProfile: Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<EmployeeDto, Employee>()
            .ForMember(dest => dest.TaskItems, opt => opt.Ignore());
    }
}