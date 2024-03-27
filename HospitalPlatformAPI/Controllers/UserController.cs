using HospitalPlatformAPI.DTOs;
using HospitalPlatformAPI.DTOs.Doctor;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ResponseDto _responseDto;
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _responseDto = new ResponseDto();
        }

        [Route("get")]
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                _responseDto.Result = _userManager.Users.ToList();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
            
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<ResponseDto> Get(string id)
        {
            try
            {
                _responseDto.Result = _userManager.Users.FirstOrDefault(u => u.Id == id);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
        
        [Route("post")]
        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] AppUser appUser)
        {
            try
            {
                _responseDto.Result = _userManager.CreateAsync(appUser);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<ResponseDto> Delete(string id)
        {
            try
            {
                var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
                _responseDto.Result = _userManager.DeleteAsync(user);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [Route("put")]
        [HttpPut]
        public async Task<ResponseDto> Put(AppUser appUser)
        {
            try
            {
                _responseDto.Result = _userManager.UpdateAsync(appUser);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        } 
}
