using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace HospitalPlatformAPI.DTOs;

public class ResetPasswordDto
{
    [Required, DataType(DataType.Password)]
    public string Password { get; set; }
    [Required, DataType(DataType.Password), Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }

    public string UserId { get; set; }
    public string Token { get; set; }
}
public class ResetPasswordDtoValidator : AbstractValidator<ResetPasswordDto>
{
    public ResetPasswordDtoValidator()
    {
        RuleFor(x => x.Password).NotEmpty().WithMessage("It cannot be empty");
        RuleFor(l => l).Custom((l, context) =>
        {
            if (l.Password != l.ConfirmPassword)
            {
                context.AddFailure("RePassword", "It must be the same");
            }

        });

    }
}