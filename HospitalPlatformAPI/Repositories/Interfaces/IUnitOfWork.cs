using HospitalPlatformAPI.Models;

namespace HospitalPlatformAPI.Repositories.Interfaces;

public interface IUnitOfWork
{
    void Commit(); 
    IGroupRepository GroupRepository { get; set; }
    ITestRepository TestRepository { get; set; }
    IGenericRepository<AppUser> AppUserRepo { get; }
}