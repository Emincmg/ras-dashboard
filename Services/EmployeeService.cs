using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RasDashboard.Areas.Identity.Data;
using RasDashboard.DTOs;
using RasDashboard.Interfaces;
using RasDashboard.Models;

namespace RasDashboard.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }

    public EmployeeDto? GetEmployeeById(string id)
    {
        var employee = _employeeRepository.GetEmployee(id);

        return _mapper.Map<EmployeeDto>(employee);
    }

    public List<EmployeeDto> GetAllEmployees()
    {
        var employees = _employeeRepository.GetEmployees();

        return _mapper.Map<List<EmployeeDto>>(employees);
    }

    public void AddEmployee(EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);
        _employeeRepository.AddEmployee(employee);
    }

    public void UpdateEmployee(EmployeeDto employeeDto)
    {
        var employee =_employeeRepository.GetEmployee(employeeDto.Id);
        _mapper.Map(employeeDto, employee);
        _employeeRepository.UpdateEmployee(employee);
    }

    public void DeleteEmployee(string id)
    {
        _employeeRepository.DeleteEmployee(id);
    }
}