using HospitalPlatformAPI.DTOs.Doctor;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;

namespace HospitalPlatformAPI.Services.Interfaces;

public interface IDoctorService
{
    List<DoctorReturnDto> Get();
    bool Add(DoctorCreateDto doctorCreateDto);
}