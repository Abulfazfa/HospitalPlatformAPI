using HospitalPlatformAPI.DAL;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HospitalPlatformAPI.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public IGroupRepository GroupRepository { get ; set ; }
    public ITestRepository TestRepository { get ; set ; }
    public IAnalysisRepository AnalysisRepository { get ; set ; }
    public IOfficeRepository OfficeRepository { get; set; }
    public IDoctorRepository DoctorRepository { get; set; }
    public IGenericRepository<AppUser> AppUserRepo { get; private set; }

    public UnitOfWork(AppDbContext appDbContext, UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager,
        IGroupRepository groupRepository, ITestRepository testRepository, IAnalysisRepository analysisRepository, IOfficeRepository officeRepository, IDoctorRepository doctorRepository)
    {
        _appDbContext = appDbContext;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        GroupRepository = groupRepository;
        TestRepository = testRepository;
        AnalysisRepository = analysisRepository;
        AppUserRepo = new GenericRepository<AppUser>(_appDbContext);
        OfficeRepository = officeRepository;
        DoctorRepository = doctorRepository;
    }

    public void Commit()
    {
        _appDbContext.SaveChanges();
    }
}