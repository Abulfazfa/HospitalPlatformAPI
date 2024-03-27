using HospitalPlatformAPI.Helpers;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.DTOs;
using HospitalPlatformAPI.DTOs.Account;
using Microsoft.AspNetCore.Identity;

namespace HospitalPlatformAPI.Services.Interfaces;

public interface IAccountService
{
    //Task<UserRegistrationResult> RegisterUser(RegisterDto registerDto);
    //Task<bool> ConfirmEmailAndSignIn(ConfirmAccountDto confirmAccountDto);
    //Task<bool> ResendOtp(string email);
    //Task<IdentityResult> ChangePassword(string userName, string currentPassword, string newPassword);
    //Task<bool> InitiatePasswordReset(string email, string resetLink);
    //Task<IdentityResult> ResetPassword(ResetPasswordDto resetPasswordDto);
    //Task<LoginResult> Login(LoginRequestDto loginDto);
    //Task Logout();
    //Task<bool> GetRoleList(string userNameOrEmail);
    Task<AppUser> GetUserByNameOrEmail(string userNameOrEmail);
    //Task<string> GeneratePasswordResetToken(AppUser existUser);
    Task<List<AppUser>> GetAllUsers();
    Task<string> Register(RegisterDto registrationRequestDto);
    Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    Task<bool> AssignRole(string email, string roleName);
}