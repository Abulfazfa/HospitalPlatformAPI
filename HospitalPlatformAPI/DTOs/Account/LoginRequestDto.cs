using FluentValidation;

namespace HospitalPlatformAPI.DTOs;

public class LoginRequestDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestDtoValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("It cannot be empty");
        RuleFor(x => x.Password).NotEmpty().WithMessage("It cannot be empty");

    }
}