using HospitalPlatformAPI.DTOs;
using HospitalPlatformAPI.DTOs.Doctor;
using HospitalPlatformAPI.DTOs.Group;
using HospitalPlatformAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ResponseDto _responseDto;
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _responseDto = new ResponseDto();
            _doctorService = doctorService;
        }

        [Route("get")]
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                _responseDto.Result = _doctorService.Get();
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
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                _responseDto.Result = _doctorService.GetGroupById(id);
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
        public async Task<ResponseDto> Post([FromBody] DoctorCreateDto doctorCreateDto)
        {
            try
            {
                _responseDto.Result = _doctorService.Add(doctorCreateDto);
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
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                _responseDto.Result = _doctorService.Delete(id);
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
        public async Task<ResponseDto> Put(DoctorUpdateDto doctorCreateDto)
        {
            try
            {
                _responseDto.Result = _doctorService.Update(doctorCreateDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
