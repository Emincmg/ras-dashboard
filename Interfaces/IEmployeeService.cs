using RasDashboard.DTOs;

namespace RasDashboard.Interfaces;

public interface IEmployeeService
{
    EmployeeDto? GetEmployeeById(string id);
    List<EmployeeDto> GetAllEmployees();
    void AddEmployee(EmployeeDto employee);
    void UpdateEmployee(EmployeeDto employee);
    void DeleteEmployee(string id);
}