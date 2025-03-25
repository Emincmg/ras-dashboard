using AutoMapper;
using RhsDashboard.DTOs.Rooms;
using RhsDashboard.Models;

namespace RhsDashboard.Mappings;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<Room, RoomDto>().ReverseMap();        
    }

}