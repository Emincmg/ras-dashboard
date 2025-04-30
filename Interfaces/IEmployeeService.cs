using RasDashboard.DTOs;

namespace RasDashboard.Interfaces;

public interface IEmployeeService
{
    /// <summary>
    /// Gets employee instance from db context with the given id.
    /// </summary>
    /// <param name="id"> ID of the employee that will be get</param>
    /// <returns></returns>
    public EmployeeDto? GetEmployeeById(string id);
    
    /// <summary>
    /// Gets all the employees from the database.
    /// </summary>
    /// <returns></returns>
    public List<EmployeeDto> GetAllEmployees();
    
    
    /// <summary>
    /// Adds a new employee to the database.
    /// </summary>
    /// <param name="employeeDto"> DTO of the employee that will be saved.</param>
    public void AddEmployee(EmployeeDto employeeDto);
    
    /// <summary>
    /// Updates an existing employee in the database.
    /// </summary>
    /// <param name="employeeDto">DTO of the employee that will be updated.</param>
    public void UpdateEmployee(EmployeeDto employeeDto);
    
    /// <summary>
    /// Deletes an employee from the database.
    /// </summary>
    /// <param name="id">ID of the employee that will be removed.</param>
    public void DeleteEmployee(string id);
}