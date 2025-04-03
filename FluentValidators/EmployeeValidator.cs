using FluentValidation;
using RasDashboard.DTOs;

namespace RasDashboard.FluentValidators;

public class EmployeeValidator:AbstractValidator<EmployeeDto>
{
    public EmployeeValidator()
    {
       RuleFor(x => x.CheckInTime)
            .NotEmpty().WithMessage("Check In Time is required")
            .Must(time => time.TimeOfDay >= TimeSpan.FromHours(6) && time.TimeOfDay <= TimeSpan.FromHours(12))
            .WithMessage("Check In Time must be between 6 AM and 12 PM");
        
        RuleFor(x => x.CheckOutTime)
            .NotEmpty().WithMessage("Check Out Time is required")
            .Must(time => time.TimeOfDay >= TimeSpan.FromHours(14) && time.TimeOfDay <= TimeSpan.FromHours(20))
            .WithMessage("Check Out Time must be between 2 PM and 8 PM")
            .GreaterThan(x => x.CheckInTime)
            .WithMessage("Check Out Time must be after Check In Time");
        
      RuleFor(x => x.LeaveStatus)
            .NotEmpty().WithMessage("Leave Status is required")
            .InclusiveBetween(0, 2).WithMessage("Leave Status must be between 0 and 2");
        
        RuleFor(x => x.Position)
            .NotEmpty().WithMessage("Position is required")
            .Length(2, 50).WithMessage("Position must be between 2 and 50 characters");
        
        RuleFor(x => x.Department)
            .NotEmpty().WithMessage("Department is required")
            .Length(2, 50).WithMessage("Department must be between 2 and 50 characters");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid")
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters");
        
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone Number is required")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number must be in E.164 format");
    }
}