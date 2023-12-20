using AutoMapper;
using HospitalPlatformAPI.DTOs.Analysis;
using HospitalPlatformAPI.DTOs.Group;
using HospitalPlatformAPI.DTOs.Office;
using HospitalPlatformAPI.DTOs.Test;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;
using HospitalPlatformAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalPlatformAPI.Services;

public class OfficeService : IOfficeService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public OfficeService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public List<ReturnOfficeDto> Get()
    {
        var offices = _unitOfWork.OfficeRepository.GetAllAsync().Result;
        var list = new List<ReturnOfficeDto>();
        foreach (var office in offices)
        {
            var result = _mapper.Map<ReturnOfficeDto>(office);
            list.Add(result);
        }
        return list;
    }
    public ReturnOfficeDto GetTestById(int id)
    {
        var test = GetTest(id);
        return _mapper.Map<ReturnOfficeDto>(test);
    }

    public bool AddOffice(CreateOfficeDto createOfficeDto)
    {
        try
        {
            var office = _mapper.Map<Office>(createOfficeDto);
            var result = _unitOfWork.OfficeRepository.AddAsync(office).GetAwaiter().GetResult;
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
            var office = GetTest(id);
            var result = _unitOfWork.OfficeRepository.DeleteAsync(office).GetAwaiter().GetResult;
            _unitOfWork.Commit();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool UpdateTest(CreateOfficeDto createOfficeDto)
    {
        var office = _mapper.Map<Office>(createOfficeDto);

        var existOffice = _unitOfWork.TestRepository.GetByIdAsync(office.Id).Result;

        if (existOffice == null)
        {
            return false;
        }

        

        _unitOfWork.Commit();
        return true;
    }

    private Office GetTest(int id)
    {
        return _unitOfWork.OfficeRepository.Include(a => a.Groups).FirstOrDefault(a => a.Id == id);
    }
}