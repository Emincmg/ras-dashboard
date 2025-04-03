using RasDashboard.DTOs;

namespace RasDashboard.Interfaces;

public interface IEmployeeService
{
    EmployeeDto? GetEmployeeById(int id);
    List<EmployeeDto> GetAllEmployees();
    void AddEmployee(EmployeeDto employee);
    void UpdateEmployee(EmployeeDto employee);
    void DeleteEmployee(int id);
}