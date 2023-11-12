using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HospitalPlatformAPI.Helpers;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.DTOs;
using HospitalPlatformAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace HospitalPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IAccountService _authService;
        private readonly IConfiguration _configuration;
        protected ResponseDto _response;
        public AccountController(IAccountService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
            _response = new();
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {

            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);

        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegisterDto model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignRoleSuccessful)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered";
                return BadRequest(_response);
            }
            return Ok(_response);

        }


    }


    //public class AccountController : ControllerBase
    //{
    //    private readonly UserManager<AppUser> _userManager;
    //    private readonly RoleManager<IdentityRole> _roleManeger;
    //    private readonly IConfiguration _config;
    //    private readonly IAccountService _accountService;
    //    protected ResponseDto _response;

    //    public AccountController(UserManager<AppUser> userManager, IConfiguration config, RoleManager<IdentityRole> roleManeger, IAccountService accountService)
    //    {
    //        _userManager = userManager;
    //        _config = config;
    //        _roleManeger = roleManeger;
    //        _accountService = accountService;
    //        _response = new ResponseDto();
    //    }

    //    [Route("register")]
    //    [HttpPost]
    //    public async Task<IActionResult> Register(RegisterDto registerDto)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return StatusCode(404);
    //        }

    //        UserRegistrationResult registrationResult = await _accountService.RegisterUser(registerDto);

    //        switch (registrationResult)
    //        {
    //            case UserRegistrationResult.Success:
    //                return StatusCode(201); //RedirectToAction(nameof(VerifyEmail), new { Email = registerVM.Email });
    //            case UserRegistrationResult.Failed:
    //                return StatusCode(401); //ModelState.AddModelError("", "User registration failed. Please try again later.");
    //                break;
    //            default:
    //                break;
    //        }

    //        return StatusCode(300);
    //    }

    //    [Route("login")]
    //    [HttpPost]
    //    public async Task<IActionResult> Login(LoginRequestDto loginDto)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return StatusCode(404);
    //        }

    //        LoginResult loginResult = await _accountService.Login(loginDto);

    //        switch (loginResult)
    //        {
    //            case LoginResult.Success:
    //                _response.IsSuccess = true;
    //            break;

    //            case LoginResult.UserNotFound:
    //                _response.Message = "Username or password is incorrect.";
    //                _response.IsSuccess = false;
    //            break;

    //            case LoginResult.UserLockedOut:
    //                _response.Message = "Your profile has been blocked.";
    //                _response.IsSuccess = false;
    //            break;

    //            case LoginResult.InvalidCredentials:
    //                _response.Message = "Username or password is incorrect.";
    //                _response.IsSuccess = false;
    //            break;
    //        }

    //        return Ok(_response);
    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> AddRole()
    //    {
    //        var result = await _roleManeger.CreateAsync(new IdentityRole { Name = "Admin" });
    //        result = await _roleManeger.CreateAsync(new IdentityRole { Name = "User" });
    //        return StatusCode(201);
    //    }

    //    //[HttpPost]
    //    //[AutoValidateAntiforgeryToken]
    //    //public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
    //    //{
    //    //    if (!ModelState.IsValid) return BadRequest("ChangePassword must be a valid change password");
    //    //    IdentityResult result = await _accountService.ChangePassword(User.Identity.Name, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);

    //    //    if (result.Succeeded)
    //    //    {
    //    //        return Ok();
    //    //    }
    //    //    else
    //    //    {
    //    //        foreach (var error in result.Errors)
    //    //        {
    //    //            ModelState.AddModelError("", error.Description);
    //    //        }
    //    //        return BadRequest("Couldn't change password'");
    //    //    }
    //    //}


    //    //[HttpPost]
    //    //[AutoValidateAntiforgeryToken]
    //    //public async Task<IActionResult> ForgotPassword(ForgetPasswordDto forgetPasswordDto)
    //    //{
    //    //    if (!ModelState.IsValid)
    //    //    {
    //    //        return BadRequest("Invalid forget password");
    //    //    }
    //    //    AppUser appUser = _accountService.GetUserByNameOrEmail(forgetPasswordDto.Email).Result;
    //    //    string token = _accountService.GeneratePasswordResetToken(appUser).Result;
    //    //    string resetLink = Url.Action(nameof(ResetPassword), "Account", new { userId = appUser.Id, token = token }, Request.Scheme, Request.Host.ToString());
    //    //    bool success = await _accountService.InitiatePasswordReset(forgetPasswordDto.Email, resetLink);

    //    //    if (success)
    //    //    {
    //    //        //return RedirectToAction(nameof(ResetPasswordVerifyEmail));
    //    //        return Ok();
    //    //    }
    //    //    else
    //    //    {
    //    //        ModelState.AddModelError("Email", "User not found");
    //    //        return BadRequest();
    //    //    }
    //    //}


    //    [HttpPost]
    //    [AutoValidateAntiforgeryToken]
    //    public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
    //    {
    //        if (!ModelState.IsValid) return BadRequest("Please check your settings");

    //        IdentityResult result = await _accountService.ResetPassword(resetPasswordDto);

    //        if (result.Succeeded)
    //        {
    //            return RedirectToAction(nameof(Login));
    //        }
    //        else
    //        {
    //            foreach (var error in result.Errors)
    //            {
    //                ModelState.AddModelError("", error.Description);
    //            }
    //            return BadRequest("Couldn't reset password");
    //        }

    //    }

    //    [Route("logout")]
    //    [HttpPost]
    //    public async Task<IActionResult> Logout()
    //    {
    //        return StatusCode(200);
    //    }
    //}
}
