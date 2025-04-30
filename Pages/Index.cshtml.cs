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

            // TODO: Tooltip for task titles
            foreach (var emp in Employees)
            {
                var currentTask = emp.TaskItems?.FirstOrDefault(t => t.IsCurrent && !t.IsCompleted);
                emp.TooltipTaskTitles = currentTask?.Tasks != null
                    ? string.Join(", ", currentTask.Tasks.Select(t => t.Title))
                    : "No tasks available";
            }
        }

        public void OnGet()
        {
            
        }
    }
}
