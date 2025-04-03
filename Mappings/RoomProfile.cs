using AutoMapper;
using RasDashboard.DTOs.Rooms;
using RasDashboard.Models;

namespace RasDashboard.Mappings;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<Room, RoomDto>().ReverseMap();        
    }

}