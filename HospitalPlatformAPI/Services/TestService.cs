using AutoMapper;
using HospitalPlatformAPI.DTOs.Group;
using HospitalPlatformAPI.DTOs.Test;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;
using HospitalPlatformAPI.Services.Interfaces;

namespace HospitalPlatformAPI.Services;

    public class TestService : ITestService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public TestService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public List<TestReturnDto> GetTests()
    {
        var tests = _unitOfWork.TestRepository.GetAllAsync().GetAwaiter().GetResult();
        var list = new List<TestReturnDto>();
        foreach (var test in tests)
        {
           list.Add(_mapper.Map<TestReturnDto>(test));
        }
        return list;
    }

    public bool AddTest(TestCreateDto testCreateDto)
    {
        try
        {
            //var test = _mapper.Map<Test>(testCreateDto);
            //var result = _unitOfWork.TestRepository.AddAsync(test).GetAwaiter().GetResult; 
            //_unitOfWork.Commit();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool DeleteTest(int id)
    {
        try
        {
            var test = GetTest(id);
            var result = _unitOfWork.TestRepository.DeleteAsync(test).GetAwaiter().GetResult; 
            _unitOfWork.Commit();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public TestReturnDto GetTestById(int id)
    {
        var test = GetTest(id);
        return _mapper.Map<TestReturnDto>(test);
    }

    public bool UpdateTest(TestCreateDto testCreateDto)
    {
        var groupEntity = _mapper.Map<Test>(testCreateDto);
        
        var existingGroup = _unitOfWork.TestRepository.GetByIdAsync(groupEntity.Id).Result;

        if (existingGroup == null)
        {
            return false;
        }

        existingGroup.AnalysisName = testCreateDto.Name;
        existingGroup.RefDoctor = testCreateDto.RefDoctor;
        _unitOfWork.Commit();
        return true;
    }


    private Test GetTest(int id)
    {
        return _unitOfWork.TestRepository.GetByIdAsync(id).GetAwaiter().GetResult();
    }
}