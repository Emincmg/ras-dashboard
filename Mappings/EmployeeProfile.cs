using AutoMapper;
using RhsDashboard.DTOs;
using RhsDashboard.Models;

namespace RhsDashboard.Mappings;

public class EmployeeProfile: Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
    }
}