using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RasDashboard.DTOs;
using RasDashboard.Interfaces;

namespace RasDashboard.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmployeeService _employeeService;
        public List<EmployeeDto> Employees { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
            Employees = _employeeService.GetAllEmployees();
        }

        public void OnGet()
        {
            
        }
    }
}
