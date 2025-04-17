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
        private EmployeeDto? _employee;
        public required List<RoomDto> Rooms { get; set; }
        public required List<TaskDto> Tasks { get; set; }
        [BindProperty]
        public TaskItemDto? TaskItem { get; set; }
        public bool EmployeeHasCurrentTask { get; set; } = false;
        public EmployeeIndexModel(IRoomsService roomsService, ITaskService taskService, UserManager<Employee> userManager, 
            IHttpContextAccessor httpContextAccessor, IEmployeeService employeeService)
        {
            _taskService = taskService;
            _roomsService = roomsService;
            _employeeService = employeeService;
            Rooms = _roomsService.GetAllRooms();
            Tasks = _taskService.GetAllTasks();
            _httpContextAccessor = httpContextAccessor;
            _employee = _employeeService.GetEmployeeById(httpContextAccessor.HttpContext?.User?.Identity?.Name!);
            
        }
        
        public void OnGet()
        {
            if (_employee != null)
            {
                TaskItem = _taskService.GetCurrentTask(_employee.Id);
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
        public async Task<IActionResult> OnPostAsync()
        {
            // Validate the task item
            if (!ModelState.IsValid || TaskItem == null)
            {
                return Page();
            }
            
            // Add the room to the task item before sending to service
            var room = await _roomsService.GetRoomByIdAsync(TaskItem.RoomId);
            TaskItem.Rooms.Add(room);
            
            // Add the employee to the task item before sending to service
            if (_employee == null)
            {
                return Page(); 
            }
            TaskItem.Employees.Add(_employee);
            
            // Set the task item properties
            TaskItem.IsCurrent = true;
            TaskItem.IsCompleted = false;
            
            await _taskService.CreateTask(TaskItem!);
            return RedirectToPage("/Employees/EmployeeIndex");
        }
    }
}
