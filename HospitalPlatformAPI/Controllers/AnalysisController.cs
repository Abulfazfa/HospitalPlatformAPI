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
        public IActionResult Get()
        {
            //try
            //{
            //    _responseDto.Result =  //_analysisService.Get();
            //}
            //catch (Exception ex)
            //{
            //    _responseDto.IsSuccess = false;
            //    _responseDto.Message = ex.Message;
            //}
            return Ok(_appDbContext.Analyses.ToList());
        }

        [Route("post")]
        [HttpPost]
        public ResponseDto Post([FromBody] AnalysisCreateDto analysisDto)
        {
            try
            {
                //_analysisService.Add(analysisDto);

                //foreach (var key in analysisDto.Key)
                //{
                //    AnalysisNameAndResultEntry resultEntry = new AnalysisNameAndResultEntry();
                //    resultEntry.Key = key;
                //    resultEntry.Value = ""; // Assign a value here if needed
                //    resultEntry.AnalysisResult = analysisResult; // Assigning AnalysisResultId
                //    analysisResult.TestNameAndResultEntry.Add(resultEntry);
                //}


                _responseDto.Result = "";
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
            return _responseDto;
        }

    }
}
