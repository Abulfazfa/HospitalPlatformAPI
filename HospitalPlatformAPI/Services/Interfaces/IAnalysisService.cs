using HospitalPlatformAPI.DTOs.Analysis;
using HospitalPlatformAPI.Models;

namespace HospitalPlatformAPI.Services.Interfaces
{
    public interface IAnalysisService
    {
        public List<Analysis> Get();
        public bool Add(AnalysisCreateDto analysisCreateDto);
    }
}
