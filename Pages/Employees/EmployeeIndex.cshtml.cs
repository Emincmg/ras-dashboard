using Microsoft.AspNetCore.Mvc.RazorPages;
using RasDashboard.DTOs;
using RasDashboard.DTOs.Rooms;
using RasDashboard.Interfaces;

namespace RasDashboard.Pages.Employees
{
    public class EmployeeIndexModel : PageModel
    {
        private readonly IRoomsService _roomsService;
        private readonly ITaskService _taskService;
        public required List<RoomDto> Rooms { get; set; }
        public required List<TaskDto> Tasks { get; set; }
        public EmployeeIndexModel(IRoomsService roomsService, ITaskService taskService)
        {
            _taskService = taskService;
            _roomsService = roomsService;
            Rooms = _roomsService.GetAllRooms();
            Tasks = _taskService.GetAllTasks();
        }
        
        public void OnGet()
        {
        }
    }
}
