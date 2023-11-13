using HospitalPlatformAPI.DTOs.Test;

namespace HospitalPlatformAPI.Services.Interfaces;

public interface ITestService
{
    List<TestReturnDto> GetTests();
    bool AddTest(TestCreateDto testCreateDto);
    bool DeleteTest(int id);
    TestReturnDto GetTestById(int id);
    bool UpdateTest(TestCreateDto testCreateDto);
}