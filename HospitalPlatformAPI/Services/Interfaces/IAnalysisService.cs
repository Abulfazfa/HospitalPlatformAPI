using HospitalPlatformAPI.DTOs.Analysis;
using HospitalPlatformAPI.Models;

namespace HospitalPlatformAPI.Services.Interfaces
{
    public interface IAnalysisService
    {
        public List<Analysis> Get();
        public Analysis Get(int id);
        public bool Delete(int id);
        //public bool Update(int id);
        public bool Add(AnalysisCreateDto analysisCreateDto);
    }
}
