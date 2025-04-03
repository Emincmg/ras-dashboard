using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RasDashboard.Areas.Identity.Data;
using RasDashboard.DTOs.Rooms;
using RasDashboard.Interfaces;

namespace RasDashboard.Services;

public class RoomsService : IRoomsService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public RoomsService(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<List<RoomDto>> GetAllRoomsAsync()
    {
        var rooms = await _roomRepository.GetAllRoomsAsync();
        return _mapper.Map<List<RoomDto>>(rooms);
    }

    public List<RoomDto> GetAllRooms()
    {
        var rooms = _roomRepository.GetAllRooms();
        return _mapper.Map<List<RoomDto>>(rooms);
    }
}