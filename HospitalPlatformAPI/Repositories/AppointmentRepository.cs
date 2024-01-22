using HospitalPlatformAPI.DAL;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;

namespace HospitalPlatformAPI.Repositories;

public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}