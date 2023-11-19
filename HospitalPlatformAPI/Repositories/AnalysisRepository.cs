using HospitalPlatformAPI.DAL;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;

namespace HospitalPlatformAPI.Repositories;

public class AnalysisRepository : GenericRepository<Analysis>, IAnalysisRepository
{
    public AnalysisRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}