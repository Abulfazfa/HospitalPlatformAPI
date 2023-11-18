using AutoMapper;
using HospitalPlatformAPI.DAL;
using HospitalPlatformAPI.DTOs;
using HospitalPlatformAPI.DTOs.Group;
using HospitalPlatformAPI.DTOs.Test;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;
using HospitalPlatformAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private ResponseDto _responseDto;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;


        public TestController(ITestService testService, IMapper mapper, AppDbContext appDbContext)
        {
            _testService = testService;
            _responseDto = new ResponseDto();
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        [Route("get")]
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                _responseDto.Result = _testService.GetTests();
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
                _responseDto.Result = _testService.GetTestById(id);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto
;
        }
        
        [Route("post")]
        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] TestCreateDto testCreateDto)
        {
            try
            {
                Test test = new()
                {
                    AnalysisName = testCreateDto.Name,
                    RefDoctor = testCreateDto.RefDoctor
                };
                var analysisResult = _appDbContext.Analyses.FirstOrDefault(a => a.Name == test.AnalysisName) == null ? null : _appDbContext.Analyses.FirstOrDefault(a => a.Name == test.AnalysisName).AnalysisResult;
                test.AnalysisResult = analysisResult;
                _appDbContext.SaveChanges();
                _responseDto.Result = _testService.AddTest(testCreateDto);
                
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
                _responseDto.Result = _testService.DeleteTest(id);
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
        public async Task<ResponseDto> Put(TestCreateDto testCreateDto)
        {
            try
            {
                _responseDto.Result = _testService.UpdateTest(testCreateDto);
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
