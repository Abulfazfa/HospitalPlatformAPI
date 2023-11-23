using HospitalPlatformAPI.DAL;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;

namespace HospitalPlatformAPI.Repositories;

public class OfficeRepository : GenericRepository<Office>, IOfficeRepository
{
    public OfficeRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}