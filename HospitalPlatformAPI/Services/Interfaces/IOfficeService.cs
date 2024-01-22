using HospitalPlatformAPI.DTOs.Office;

namespace HospitalPlatformAPI.Services.Interfaces;

public interface IOfficeService
{
    public List<ReturnOfficeDto> Get();
    ReturnOfficeDto GetOfficeById(int id);
    bool AddOffice(CreateOfficeDto createOfficeDto);
    bool DeleteOffice(int id);
    bool UpdateOffice(CreateOfficeDto createOfficeDto);
}