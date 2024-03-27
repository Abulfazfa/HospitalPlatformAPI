using AutoMapper;
using HospitalPlatformAPI.DTOs.Analysis;
using HospitalPlatformAPI.DTOs.Group;
using HospitalPlatformAPI.DTOs.Test;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;
using HospitalPlatformAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        var tests = _unitOfWork.TestRepository.Include(a => a.TestResult).Include(a => a.TestResult.TestNameAndResultEntry).ToList();
        var list = new List<TestReturnDto>();
        foreach (var test in tests)
        {
            var result = _mapper.Map<TestReturnDto>(test);
            List<TestNameAndResultEntryDto> testNameAndResultEntryDtos= new List<TestNameAndResultEntryDto>();
            foreach (var resultEntry in test.TestResult.TestNameAndResultEntry)
            {
                TestNameAndResultEntryDto testNameAndResultEntry = new();
                testNameAndResultEntry.Key = resultEntry.Key;
                testNameAndResultEntry.Value = resultEntry.Value;
                testNameAndResultEntryDtos.Add(testNameAndResultEntry);
                //result.TestNameAndResultEntry.Add(testNameAndResultEntry);
                
            }
            result.TestNameAndResultEntry = testNameAndResultEntryDtos;
           list.Add(result);
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
                AnalysisName = testCreateDto.AnalysisName,
                RefDoctor = testCreateDto.RefDoctor
            };
            var analysis = _unitOfWork.AnalysisRepository.GetByPredicateAsync(a => a.Name == test.AnalysisName).Result;
            var user = _unitOfWork.AppUserRepo.GetAllAsync().Result
                .FirstOrDefault(a => a.FullName == testCreateDto.User);
            if (analysis != null)
            {
                var analysisResult = _unitOfWork.AnalysisRepository.Include(a => a.AnalysisResult).Include(a => a.AnalysisResult.TestNameAndResultEntry)
                    .FirstOrDefault(a => a.Name == test.AnalysisName).AnalysisResult;

                test.TestPrice = analysis.Price;
                TestResult testResult = new TestResult();
                foreach (var item in analysisResult.TestNameAndResultEntry)
                {
                    TestNameAndResultEntry testNameAndResultEntry = new();
                    testNameAndResultEntry.Key = item.Key;
                    testNameAndResultEntry.Value = item.Value;
                    testResult.TestNameAndResultEntry.Add(testNameAndResultEntry);
                }
                test.TestResult = testResult;
                user.Tests.Add(test);
            }

            _unitOfWork.TestRepository.AddAsync(test);
            _unitOfWork.AppUserRepo.UpdateAsync(user);
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

        existingGroup.AnalysisName = testCreateDto.AnalysisName;
        existingGroup.RefDoctor = testCreateDto.RefDoctor;
        _unitOfWork.Commit();
        return true;
    }


    private Test GetTest(int id)
    {
        return _unitOfWork.TestRepository.Include(a =>a.TestResult).FirstOrDefault(a => a.Id == id);
    }
}