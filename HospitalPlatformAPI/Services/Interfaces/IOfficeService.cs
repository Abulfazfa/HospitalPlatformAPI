using HospitalPlatformAPI.DTOs.Office;

namespace HospitalPlatformAPI.Services.Interfaces;

public interface IOfficeService
{
    public List<ReturnOfficeDto> Get();
    ReturnOfficeDto GetTestById(int id);
    bool AddOffice(CreateOfficeDto createOfficeDto);
    bool DeleteTest(int id);
    bool UpdateTest(CreateOfficeDto createOfficeDto);
}