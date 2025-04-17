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
            var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    
            if (!string.IsNullOrEmpty(userId))
            {
                _employee = _employeeService.GetEmployeeById(userId);
            }
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
            
            foreach (var id in TaskIds)
            {
                var task = await _taskService.GetTaskByIdAsync(id);
                TaskItem.Tasks.Add(task);
            }
            
            // Add the rooms to the task item before sending to service
            foreach (var roomId in RoomIds)
            {
                var room = await _roomsService.GetRoomByIdAsync(roomId);
                TaskItem.Rooms.Add(room);
            }
            
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
