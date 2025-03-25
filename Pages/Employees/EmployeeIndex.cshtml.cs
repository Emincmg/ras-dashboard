using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RhsDashboard.DTOs;
using RhsDashboard.DTOs.Rooms;
using RhsDashboard.Interfaces;

namespace RhsDashboard.Pages.Employees
{
    public class EmployeeIndexModel : PageModel
    {
        private readonly IRoomsService _roomsService;
        public required List<RoomDto> Rooms { get; set; }
        
        public EmployeeIndexModel(IRoomsService roomsService)
        {
            _roomsService = roomsService;
            Rooms = _roomsService.GetAllRooms();
        }
        
        public void OnGet()
        {
        }
    }
}
