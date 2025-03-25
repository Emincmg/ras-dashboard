using Microsoft.AspNetCore.Mvc;
using RhsDashboard.DTOs;
using FluentValidation;
using FluentValidation.Results;
using RhsDashboard.Interfaces;

namespace RhsDashboard.Controllers;

public class TaskController : Controller
{
    private readonly IValidator<TaskItemDto> _validator;
    private readonly ITaskService _taskService;

    public TaskController(IValidator<TaskItemDto> taskItemValidator, ITaskService taskService)
    {
        _validator = taskItemValidator;
        _taskService = taskService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTask([FromBody] TaskItemDto taskDto)
    {
        ValidationResult result = await _validator.ValidateAsync(taskDto);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }

        await _taskService.CreateTask(taskDto);

        return Ok("Task created successfully!");
    }
}