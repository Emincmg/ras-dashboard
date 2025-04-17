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

    /// <summary>
    /// Gets employee instance from db context with the given id.
    /// </summary>
    /// <param name="id"> ID of the employee that will be get</param>
    /// <returns></returns>
    public EmployeeDto? GetEmployeeById(string id)
    {
        var employee = _context.Employees.Find(id);
        return employee != null ? _mapper.Map<EmployeeDto>(employee) : null;
    }

    /// <summary>
    /// Gets all the employees from the database.
    /// </summary>
    /// <returns></returns>
    public List<EmployeeDto> GetAllEmployees()
    {
        var employees = _context.Employees.ToList();
        return _mapper.Map<List<EmployeeDto>>(employees);
    }

    /// <summary>
    /// Adds a new employee to the database.
    /// </summary>
    /// <param name="employeeDto"> DTO of the employee that will be saved.</param>
    public void AddEmployee(EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    /// <summary>
    /// Updates an existing employee in the database.
    /// </summary>
    /// <param name="employeeDto">DTO of the employee that will be updated.</param>
    public void UpdateEmployee(EmployeeDto employeeDto)
    {
        var employee = _context.Employees.Find(employeeDto.Id);
        if (employee != null)
        {
            _mapper.Map(employeeDto, employee);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Deletes an employee from the database.
    /// </summary>
    /// <param name="id">ID of the employee that will be removed.</param>
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