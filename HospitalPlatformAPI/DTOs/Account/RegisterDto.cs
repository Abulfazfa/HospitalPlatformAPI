using FluentValidation;

namespace HospitalPlatformAPI.DTOs;

public class RegisterDto
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string? Role { get; set; }

}
public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("It cannot be empty");
        RuleFor(x => x.Email).NotEmpty().WithMessage("It cannot be empty").EmailAddress().WithMessage("Please enter your email address");
        RuleFor(x => x.Password).NotEmpty().WithMessage("It cannot be empty").EmailAddress().WithMessage("Please enter your email address");
    }
}