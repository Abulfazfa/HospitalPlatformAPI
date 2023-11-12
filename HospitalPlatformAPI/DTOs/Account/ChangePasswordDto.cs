using FluentValidation;

namespace HospitalPlatformAPI.DTOs;

public class ChangePasswordDto
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmNewPassword { get; set; }
}
public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
{
    public ChangePasswordDtoValidator()
    {
        RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage("It cannot be empty");
        RuleFor(x => x.NewPassword).NotEmpty().WithMessage("It cannot be empty");
        RuleFor(l => l).Custom((l, context) =>
        {
            if (l.CurrentPassword != l.ConfirmNewPassword)
            {
                context.AddFailure("RePassword", "It must be the same");
            }

        });

    }
}