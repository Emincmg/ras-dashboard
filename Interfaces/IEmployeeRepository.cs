using RasDashboard.Models;

namespace RasDashboard.Interfaces;

public interface IEmployeeRepository
{
    /// <summary>
    /// Get all employees from db.
    /// </summary>
    /// <returns>A list of EmployeeDto insances</returns>
    List<Employee> GetEmployees();
    
    /// <summary>
    /// Get all employees from db async
    /// </summary>
    /// <returns>A list of EmployeeDto insances</returns>
    Task<List<Employee>> GetEmployeesAsync();
    
    /// <summary>
    /// Get an employee from db
    /// </summary>
    /// <param name="id"></param>
    /// <returns>An Employee instance</returns>
    Employee GetEmployee(string id);
    
    /// <summary>
    /// Get an employee from db async
    /// </summary>
    /// <param name="id"></param>
    /// <returns>An Employee instance</returns>
    Task<Employee> GetEmployeeAsync(string id);
    
    /// <summary>
    /// Create an employee
    /// </summary>
    /// <param name="employee"></param>
    void AddEmployee(Employee employee);
    
    /// <summary>
    /// Create an employee async
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    Task AddEmployeeAsync(Employee employee);
    
    /// <summary>
    /// Update an employee
    /// </summary>
    /// <param name="employee"></param>
    void UpdateEmployee(Employee employee);
    
    /// <summary>
    /// Update an employee async
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    Task UpdateEmployeeAsync(Employee employee);
    
    /// <summary>
    /// Delete an employee
    /// </summary>
    /// <param name="id"></param>
    void DeleteEmployee(string id);
    
    /// <summary>
    /// Delete an employee async
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteEmployeeAsync(string id);
    
    /// <summary>
    /// Generates a default password for Employee creation.
    /// </summary>
    /// <returns></returns>
    string GenerateDefaultPassword(string userName);
}