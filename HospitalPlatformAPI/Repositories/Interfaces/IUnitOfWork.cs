using HospitalPlatformAPI.Models;

namespace HospitalPlatformAPI.Repositories.Interfaces;

public interface IUnitOfWork
{
    void Commit(); 
    IGroupRepository GroupRepository { get; set; }
    ITestRepository TestRepository { get; set; }
    IAnalysisRepository AnalysisRepository { get; set; }
    IGenericRepository<AppUser> AppUserRepo { get; }
}