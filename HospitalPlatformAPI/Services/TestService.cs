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
        var tests = _unitOfWork.TestRepository.Include(a => a.AnalysisResult).ToList();
        var list = new List<TestReturnDto>();
        foreach (var test in tests)
        {
           list.Add(_mapper.Map<TestReturnDto>(test));
        }
        return list;
    }
    public TestReturnDto GetTestById(int id)
    {
        var test = GetTest(id);
        return _mapper.Map<TestReturnDto>(test);
    }

    public bool AddTest(TestCreateDto testCreateDto)
    {
        try
        {
            Test test = new()
            {
                AnalysisName = testCreateDto.Name,
                RefDoctor = testCreateDto.RefDoctor
            };
            var analysis = _unitOfWork.AnalysisRepository.GetByPredicateAsync(a => a.Name == test.AnalysisName).Result;
            if (analysis != null)
            {
                var analysisResult = _unitOfWork.AnalysisRepository.Include(a => a.AnalysisResult).FirstOrDefault(a => a.Name == test.AnalysisName).AnalysisResult;
                test.AnalysisResult = analysisResult;
                test.AnalysisPrice = analysis.Price;
            }

            _unitOfWork.TestRepository.AddAsync(test);
            _unitOfWork.Commit();
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
        return _unitOfWork.TestRepository.Include(a =>a.AnalysisResult).FirstOrDefault(a => a.Id == id);
    }
}