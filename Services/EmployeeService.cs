using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RasDashboard.Areas.Identity.Data;
using RasDashboard.DTOs;
using RasDashboard.Interfaces;
using RasDashboard.Models;

namespace RasDashboard.Services;

public class EmployeeService : IEmployeeService
{
    private readonly RasDashboardContext _context;
    private readonly IMapper _mapper;

    public EmployeeService(RasDashboardContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public EmployeeDto? GetEmployeeById(string id)
    {
        var employee = _context.Employees
            .Include(e => e.TaskItems)
            .FirstOrDefault(e => e.Id == id); 

        return employee != null ? _mapper.Map<EmployeeDto>(employee) : null;
    }

    /// <inheritdoc />
    public List<EmployeeDto> GetAllEmployees()
    {
        var employees = _context.Employees
    .Include(e => e.TaskItems)
        .ThenInclude(ti => ti.Tasks)
    .Include(e => e.TaskItems)
        .ThenInclude(ti => ti.Rooms)
    .ToList();
        return _mapper.Map<List<EmployeeDto>>(employees);
    }

    /// <inheritdoc />
    public void AddEmployee(EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    /// <inheritdoc />
    public void UpdateEmployee(EmployeeDto employeeDto)
    {
        var employee = _context.Employees.Find(employeeDto.Id);
        if (employee != null)
        {
            _mapper.Map(employeeDto, employee);
            _context.SaveChanges();
        }
    }

    /// <inheritdoc />
    public void DeleteEmployee(string id)
    {
        var employee = _context.Employees.Find(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}