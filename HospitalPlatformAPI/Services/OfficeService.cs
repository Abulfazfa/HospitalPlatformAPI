using AutoMapper;
using HospitalPlatformAPI.DTOs.Analysis;
using HospitalPlatformAPI.DTOs.Group;
using HospitalPlatformAPI.DTOs.Office;
using HospitalPlatformAPI.DTOs.Test;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;
using HospitalPlatformAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
		Expression<Func<Office, object>>[] includes = {
	        c => c.Groups.Select(p => p.Doctors)
        };



		var offices = _unitOfWork.OfficeRepository.Include(o => o.Groups).ToList();
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
        var test = GetOffice(id);
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
            var office = GetOffice(id);
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

    private Office GetOffice(int id)
    {
        return _unitOfWork.OfficeRepository.Include(a => a.Groups).FirstOrDefault(a => a.Id == id);
    }
}