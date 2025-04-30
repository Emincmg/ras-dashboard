using Microsoft.EntityFrameworkCore;
using RasDashboard.Areas.Identity.Data;
using RasDashboard.Interfaces;
using RasDashboard.Models;

namespace RasDashboard.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly RasDashboardContext _context;
    
    public EmployeeRepository(RasDashboardContext context)
    {
        _context = context;
    }
    
    public List<Employee> GetEmployees()
    {
        var employees = _context.Employees
            .Where(e => e.Position == "Employee")
            .Include(e => e.TaskItems)!
            .ThenInclude(ti => ti.Tasks)
            .Include(e => e.TaskItems)!
            .ThenInclude(ti => ti.Rooms)
            .ToList();
        if (employees.Count == 0)
        {
            employees = [];
        }

        return employees;
    }

    public Task<List<Employee>> GetEmployeesAsync()
    {
        throw new NotImplementedException();
    }

    public Employee GetEmployee(string id)
    {
        var employee =  _context.Employees
            .Include(e => e.TaskItems)
            .FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            throw new Exception("Employee not found with given id. Given ID = " +id);
        }
        
        return employee;
    }

    public Task<Employee> GetEmployeeAsync(string id)
    {
        throw new NotImplementedException();
    }

    public void AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public Task AddEmployeeAsync(Employee employee)
    {
        throw new NotImplementedException();
    }

    public void UpdateEmployee(Employee employee)
    {
       _context.SaveChanges();
    }

    public Task UpdateEmployeeAsync(Employee employee)
    {
        throw new NotImplementedException();
    }

    public void DeleteEmployee(string id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null)
        {
            throw new Exception("Employee not found with given id. Given ID = " +id);
        }
        _context.Employees.Remove(employee);
        _context.SaveChanges();
    }

    public Task DeleteEmployeeAsync(string id)
    {
        throw new NotImplementedException();
    }
}