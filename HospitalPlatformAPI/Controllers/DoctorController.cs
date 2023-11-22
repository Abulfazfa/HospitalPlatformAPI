using AutoMapper;
using HospitalPlatformAPI.DTOs;
using HospitalPlatformAPI.DTOs.Group;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
         private readonly ResponseDto _responseDto;
        private readonly IMapper _mapper;

        public DoctorController(IMapper mapper)
        {
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }

        [Route("get")]
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                //_responseDto.Result = _groupService.GetGroups();
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
                //_responseDto.Result = _groupService.GetGroupById(id);
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
        public async Task<ResponseDto> Post([FromBody] GroupCreateDto groupCreateDto)
        {
            try
            {
                //_responseDto.Result = _groupService.AddGroup(groupCreateDto);
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
                //_responseDto.Result = _groupService.DeleteGroup(id);
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
        public async Task<ResponseDto> Put(GroupCreateDto groupCreateDto)
        {
            try
            {
                //_responseDto.Result = _groupService.UpdateGroup(groupCreateDto);
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
