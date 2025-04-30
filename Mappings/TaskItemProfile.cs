using AutoMapper;
using RasDashboard.DTOs;
using RasDashboard.Models;

namespace RasDashboard.Mappings;

public class TaskItemProfile : Profile
{
    public TaskItemProfile()
    {
        // DTO → Entity
        CreateMap<TaskItemDto, TaskItem>()
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src =>
                src.TaskIds.Select(id => new EmployeeTask { Id = id }).ToList()))
            .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src =>
                src.RoomIds.Select(id => new Room { Id = id }).ToList()))
            .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != Guid.Empty));

        // Entity → DTO
        CreateMap<TaskItem, TaskItemDto>()
            .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
      .ForMember(dest => dest.TaskIds, opt => opt.MapFrom(src =>
          src.Tasks.Select(t => t.Id).ToList()))
      .ForMember(dest => dest.RoomIds, opt => opt.MapFrom(src =>
          src.Rooms.Select(r => r.Id).ToList()));

    }
}