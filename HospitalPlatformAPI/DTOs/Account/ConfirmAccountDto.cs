using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace HospitalPlatformAPI.DTOs;

public class ConfirmAccountDto
{
    public string Email { get; set; }
    public string OTP { get; set; }
}
public class ConfirmAccountDtoValidator : AbstractValidator<ConfirmAccountDto>
{
    public ConfirmAccountDtoValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("It cannot be empty");
        RuleFor(x => x.OTP).NotEmpty().WithMessage("It cannot be empty");
    }
}