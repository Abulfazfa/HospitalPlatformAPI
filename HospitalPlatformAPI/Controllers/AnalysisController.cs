using HospitalPlatformAPI.DAL;
using HospitalPlatformAPI.DTOs;
using HospitalPlatformAPI.DTOs.Analysis;
using HospitalPlatformAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisService _analysisService;
        private readonly AppDbContext _appDbContext;
        private readonly ResponseDto _responseDto;

        public AnalysisController(AppDbContext appDbContext, IAnalysisService analysisService)
        {
            _appDbContext = appDbContext;
            _responseDto = new ResponseDto();
            _analysisService = analysisService;
        }

        [Route("get")]
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                _responseDto.Result = _analysisService.Get();
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
        public ResponseDto Get(int id)
        {
            try
            {
                _responseDto.Result = _analysisService.Get(id);
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
        public ResponseDto Post([FromBody] AnalysisCreateDto analysisDto)
        {
            try
            {
                _responseDto.Result =  _analysisService.Add(analysisDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [Route("delete")]
        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            { 
                _responseDto.Result = _analysisService.Delete(id);
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
