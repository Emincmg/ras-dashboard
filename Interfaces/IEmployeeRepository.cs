using RasDashboard.Models;

namespace RasDashboard.Interfaces;

public interface IEmployeeRepository
{
    /// <summary>
    /// Get all employees from db.
    /// </summary>
    /// <returns>A list of EmployeeDto insances</returns>
    public List<Employee> GetEmployees();
    
    /// <summary>
    /// Get all employees from db async
    /// </summary>
    /// <returns>A list of EmployeeDto insances</returns>
    public Task<List<Employee>> GetEmployeesAsync();
    
    /// <summary>
    /// Get an employee from db
    /// </summary>
    /// <param name="id"></param>
    /// <returns>An Employee instance</returns>
    public Employee GetEmployee(string id);
    
    /// <summary>
    /// Get an employee from db async
    /// </summary>
    /// <param name="id"></param>
    /// <returns>An Employee instance</returns>
    public Task<Employee> GetEmployeeAsync(string id);
    
    /// <summary>
    /// Create an employee
    /// </summary>
    /// <param name="employee"></param>
    public void AddEmployee(Employee employee);
    
    /// <summary>
    /// Create an employee async
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public Task AddEmployeeAsync(Employee employee);
    
    /// <summary>
    /// Update an employee
    /// </summary>
    /// <param name="employee"></param>
    public void UpdateEmployee(Employee employee);
    
    /// <summary>
    /// Update an employee async
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public Task UpdateEmployeeAsync(Employee employee);
    
    /// <summary>
    /// Delete an employee
    /// </summary>
    /// <param name="id"></param>
    public void DeleteEmployee(string id);
    
    /// <summary>
    /// Delete an employee async
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task DeleteEmployeeAsync(string id);
}