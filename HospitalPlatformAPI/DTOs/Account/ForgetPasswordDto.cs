using FluentValidation;

namespace HospitalPlatformAPI.DTOs;

public class ForgetPasswordDto
{
    public string Email { get; set; }
}

public class ForgetPasswordDtoValidator : AbstractValidator<ForgetPasswordDto>
{
    public ForgetPasswordDtoValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("It must be not empty");
    }
}