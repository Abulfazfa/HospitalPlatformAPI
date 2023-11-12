using HospitalPlatformAPI.DAL;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;

namespace HospitalPlatformAPI.Repositories;

public class TestRepository : GenericRepository<Test>, ITestRepository
{
    public TestRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}