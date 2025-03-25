using AutoMapper;
using RhsDashboard.Areas.Identity.Data;
using RhsDashboard.DTOs;
using RhsDashboard.Interfaces;
using RhsDashboard.Models;

namespace RhsDashboard.Services;

public class EmployeeService : IEmployeeService
{
    private readonly RhsDashboardContext _context;
    private readonly IMapper _mapper;

    public EmployeeService(RhsDashboardContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public EmployeeDto? GetEmployeeById(int id)
    {
        var employee = _context.Employees.Find(id);
        return employee != null ? _mapper.Map<EmployeeDto>(employee) : null;
    }

    public List<EmployeeDto> GetAllEmployees()
    {
        var employees = _context.Employees.ToList();
        return _mapper.Map<List<EmployeeDto>>(employees);
    }

    public void AddEmployee(EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public void UpdateEmployee(EmployeeDto employeeDto)
    {
        var employee = _context.Employees.Find(employeeDto.Id);
        if (employee != null)
        {
            _mapper.Map(employeeDto, employee);
            _context.SaveChanges();
        }
    }

    public void DeleteEmployee(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}