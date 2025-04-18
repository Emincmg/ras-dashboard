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

    /// <inheritdoc />
    public async Task<List<RoomDto>> GetAllRoomsAsync()
    {
        var rooms = await _roomRepository.GetAllRoomsAsync();
        return _mapper.Map<List<RoomDto>>(rooms);
    }

    /// <inheritdoc />
    public RoomDto GetRoomById(int id)
    {
        var room = _roomRepository.GetRoomById(id);
        return _mapper.Map<RoomDto>(room);
    }
    
    /// <inheritdoc />
    public async Task<RoomDto> GetRoomByIdAsync(int id)
    {
        var room = await _roomRepository.GetRoomByIdAsync(id);
        return _mapper.Map<RoomDto>(room);
    }

    /// <inheritdoc />
    public List<RoomDto> GetAllRooms()
    {
        var rooms = _roomRepository.GetAllRooms();
        return _mapper.Map<List<RoomDto>>(rooms);
    }
}