using HospitalPlatformAPI.DTOs.Doctor;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;

namespace HospitalPlatformAPI.Services.Interfaces;

public interface IDoctorService
{
    List<DoctorReturnDto> Get();
    DoctorReturnDto GetGroupById(int id);
    bool Add(DoctorCreateDto doctorCreateDto); 
    bool Delete(int id);
    bool Update(DoctorCreateDto createDto);
}