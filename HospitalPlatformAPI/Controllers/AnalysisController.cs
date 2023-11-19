using HospitalPlatformAPI.DAL;
using HospitalPlatformAPI.DTOs;
using HospitalPlatformAPI.DTOs.Analysis;
using HospitalPlatformAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly ResponseDto _responseDto;

        public AnalysisController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _responseDto = new ResponseDto();
        }
        
        [Route("get")]
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                _responseDto.Result = _appDbContext.Analyses.ToList();
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
                AnalysisResult analysisResult = new AnalysisResult();

                foreach (var key in analysisDto.Key)
                {
                    AnalysisNameAndResultEntry resultEntry = new AnalysisNameAndResultEntry();
                    resultEntry.Key = key;
                    resultEntry.Value = ""; // Assign a value here if needed
                    resultEntry.AnalysisResult = analysisResult; // Assigning AnalysisResultId
                    analysisResult.TestNameAndResultEntry.Add(resultEntry);
                }

                Analysis analysis = new Analysis
                {
                    Name = analysisDto.Name,
                    Price = analysisDto.Price,
                    AnalysisResult = analysisResult
                };

                var addedAnalysis = _appDbContext.Analyses.Add(analysis);
                _appDbContext.SaveChanges();

                _responseDto.Result = addedAnalysis.Entity;
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
