using AutoMapper;
using HospitalPlatformAPI.Helpers;
using HospitalPlatformAPI.DTOs;
using HospitalPlatformAPI.DTOs.Account;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;
using HospitalPlatformAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static HospitalPlatformAPI.Services.Interfaces.IJwtTokenGenerator;

namespace HospitalPlatformAPI.Services;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AccountService( IUnitOfWork unitOfWork, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
    }


    public async Task<bool> AssignRole(string email, string roleName)
    {
        var user = GetUserByNameOrEmail(email).GetAwaiter().GetResult();
        if (user != null)
        {
            if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
            }
            await _userManager.AddToRoleAsync(user, roleName);
            return true;
        }
        return false;

    }

    public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        var user = GetUserByNameOrEmail(loginRequestDto.UserName).GetAwaiter().GetResult();

        bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

        if (user == null || isValid == false)
        {
            return new LoginResponseDto() { User = null, Token = "" };
        }

        //if user was found , Generate JWT Token
        var roles = _userManager.GetRolesAsync(user).GetAwaiter().GetResult();
        var token = _jwtTokenGenerator.GenerateToken(user, roles);

        UserDto userDTO = new()
        {
            //Email = user.Email,
            ID = user.Id,
            Name = user.UserName,
            PhoneNumber = user.PhoneNumber
        };

        LoginResponseDto loginResponseDto = new LoginResponseDto()
        {
            User = userDTO,
            Token = token
        };

        return loginResponseDto;
    }

    public async Task<string> Register(RegisterDto registrationRequestDto)
    {
        AppUser user = new()
        {
            UserName = registrationRequestDto.Email,
            Email = registrationRequestDto.Email,
            NormalizedEmail = registrationRequestDto.Email.ToUpper(),
            FullName = registrationRequestDto.Name
        };

        try
        {
            var result = _userManager.CreateAsync(user, registrationRequestDto.Password).GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                var userToReturn = GetUserByNameOrEmail(user.Email).GetAwaiter().GetResult();

                UserDto userDto = new()
                {
                    //Email = userToReturn.Email,
                    ID = userToReturn.Id,
                    Name = userToReturn.UserName,
                    PhoneNumber = userToReturn.PhoneNumber
                };

                return "";
            }
            else
            {
                return result.Errors.FirstOrDefault().Description;
            }

        }
        catch (Exception ex)
        {

        }
        return "Error Encountered";
    }

    public async Task<AppUser> GetUserByNameOrEmail(string userNameOrEmail)
    {
        return await _userManager.FindByNameAsync(userNameOrEmail) ?? await _userManager.FindByEmailAsync(userNameOrEmail);
    }
    public async Task<List<AppUser>> GetAllUsers()
    {
        return await _userManager.Users.ToListAsync();
    }
    
}