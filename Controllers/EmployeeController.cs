using Microsoft.AspNetCore.Mvc;
using RasDashboard.DTOs;
using RasDashboard.Interfaces;

namespace RasDashboard.Controllers;

public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("{id}")]
    public ActionResult<EmployeeDto?> GetEmployeeById(string id)
    {
        var employee = _employeeService.GetEmployeeById(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpGet]
    public ActionResult<IEnumerable<EmployeeDto>> GetAllEmployees()
    {
        var employees = _employeeService.GetAllEmployees();
        return Ok(employees);
    }

    [HttpPost]
    public ActionResult AddEmployee(EmployeeDto employeeDto)
    {
        _employeeService.AddEmployee(employeeDto);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeDto.Id }, employeeDto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateEmployee(int id, EmployeeDto employeeDto)
    {
        // deprecated because if ms identity is used, the id is hashed so in dto it is string
        // if (id != employeeDto.Id)
        // {
        //     return BadRequest();
        // }

        _employeeService.UpdateEmployee(employeeDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteEmployee(string id)
    {
        _employeeService.DeleteEmployee(id);
        return NoContent();
    }
}