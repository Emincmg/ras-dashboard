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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string? _userId;
        public required List<RoomDto> Rooms { get; set; }
        public required List<TaskDto> Tasks { get; set; }
        [BindProperty] public TaskItemDto? TaskItem { get; set; }
        public bool EmployeeHasCurrentTask { get; set; } = false;
        public List<Guid> TaskIds { get; set; } = [];
        public List<int> RoomIds { get; set; } = [];

        public EmployeeIndexModel(IRoomsService roomsService, ITaskService taskService,
            UserManager<Employee> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _taskService = taskService;
            _roomsService = roomsService;
            Rooms = _roomsService.GetAllRooms();
            Tasks = _taskService.GetAllTasks();
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            _userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_userId != null)
            {
                TaskItem = _taskService.GetCurrentTask(_userId);
                EmployeeHasCurrentTask = TaskItem != null;
            }
            else
            {
                TaskItem = new TaskItemDto();
            }

            Rooms = _roomsService.GetAllRooms();
            Tasks = _taskService.GetAllTasks();
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

            _userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_userId != null)
            {
                TaskItem.EmployeeId = _userId;
            }

            switch (action)
            {
                case "update":
                    await _taskService.UpdateTask(TaskItem);
                    break;
                
                case "stop":
                    TaskItem.IsCurrent = false;
                    TaskItem.IsCompleted = true;
                    await _taskService.UpdateTask(TaskItem);
                    break;

                case "create":
                    TaskItem.IsCurrent = true;
                    await _taskService.CreateTask(TaskItem);
                    break;

                default:
                    return Page();
            }

            return RedirectToPage("/Employees/EmployeeIndex");
        }
    }
}