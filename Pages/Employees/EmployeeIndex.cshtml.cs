using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RasDashboard.DTOs;
using RasDashboard.DTOs.Rooms;
using RasDashboard.Interfaces;
using RasDashboard.Models;

namespace RasDashboard.Pages.Employees
{
    public class EmployeeIndexModel : PageModel
    {
        private readonly IRoomsService _roomsService;
        private readonly ITaskService _taskService;
        private readonly IEmployeeService _employeeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string? _userId;
        public required List<RoomDto> Rooms { get; set; }
        public required List<TaskDto> Tasks { get; set; }
        [BindProperty]
        public TaskItemDto? TaskItem { get; set; }
        public bool EmployeeHasCurrentTask { get; set; } = false;
        public List<Guid> TaskIds { get; set; } = [];
        public List<int> RoomIds { get; set; } = [];
        public EmployeeIndexModel(IRoomsService roomsService, ITaskService taskService, UserManager<Employee> userManager, 
            IHttpContextAccessor httpContextAccessor, IEmployeeService employeeService)
        {
            _taskService = taskService;
            _roomsService = roomsService;
            _employeeService = employeeService;
            Rooms = _roomsService.GetAllRooms();
            Tasks = _taskService.GetAllTasks();
            _httpContextAccessor = httpContextAccessor;
            _userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        
        public void OnGet()
        {
            if (_userId != null)
            {
                TaskItem = _taskService.GetCurrentTask(_userId);
            }
            
            if (TaskItem != null)
            {
                EmployeeHasCurrentTask = true;
            }
        }

        /// <summary>
        /// Create task item for the employee.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(string action)
        {
            if (!ModelState.IsValid || TaskItem == null)
            {
                return Page();
            }
            
            switch (action)
            {
                case "update":
                    // Update the current task.
                    await _taskService.UpdateTask(TaskItem);
                    break;

                case "startStop":
                    // Toggle the current task state.
                    if (TaskItem.IsCurrent)
                    {
                        TaskItem.IsCurrent = false;
                        TaskItem.IsCompleted = true;
                    }
                    else
                    {
                        TaskItem.IsCurrent = true;
                        TaskItem.IsCompleted = false;
                    }
                    await _taskService.UpdateTask(TaskItem);
                    break;

                default:
                    return Page();
            }

            return RedirectToPage("/Employees/EmployeeIndex");
        }

    }
}
