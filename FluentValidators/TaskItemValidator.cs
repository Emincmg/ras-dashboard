using FluentValidation;
using RasDashboard.DTOs;
using RasDashboard.Models;
namespace RasDashboard.FluentValidators;

public class TaskItemValidator : AbstractValidator<TaskItemDto>
{
    public TaskItemValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(x => x.DueDate)
            .GreaterThanOrEqualTo(DateTime.Now).WithMessage("DueDate cannot be in the past.");

        RuleFor(x => x.StartTime)
            .LessThan(x => x.EndTime).WithMessage("StartTime must be before EndTime.");

        RuleFor(x => x.Tasks)
            .NotNull().WithMessage("Tasks list cannot be null.");

        RuleFor(x => x.Rooms)
            .NotNull().WithMessage("Rooms list cannot be null.");

        RuleFor(x => x.Employees)
            .NotNull().WithMessage("Employees list cannot be null.");
    }
}
