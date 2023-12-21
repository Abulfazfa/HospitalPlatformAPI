using AutoMapper;
using HospitalPlatformAPI.DTOs.Doctor;
using HospitalPlatformAPI.DTOs.Group;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories;
using HospitalPlatformAPI.Repositories.Interfaces;
using HospitalPlatformAPI.Services.Interfaces;

namespace HospitalPlatformAPI.Services;

public class DoctorService : IDoctorService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DoctorService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public List<DoctorReturnDto> Get()
    {
        var doctors = _unitOfWork.DoctorRepository.GetAllAsync().Result;
        var list = new List<DoctorReturnDto>();
        foreach (var doctor in doctors)
        {
            list.Add(_mapper.Map<DoctorReturnDto>(doctor));
        }
        return list;
    }

    public bool Add(DoctorCreateDto doctorCreateDto)
    {
        try
        {
            var doctor = _mapper.Map<Doctor>(doctorCreateDto);
            doctor.GroupId = _unitOfWork.GroupRepository.GetByPredicateAsync(d => d.Name == doctorCreateDto.Branch).Result.Id;
            doctor.OfficeId = _unitOfWork.OfficeRepository.GetByPredicateAsync(d => d.Name == doctorCreateDto.WorkingOffice).Result.Id;
            var result = _unitOfWork.DoctorRepository.AddAsync(doctor).GetAwaiter().GetResult;
            _unitOfWork.Commit();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var group = Get(id);
            var result = _unitOfWork.GroupRepository.DeleteAsync(group).GetAwaiter().GetResult;
            _unitOfWork.Commit();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Update(GroupCreateDto groupCreateDto)
    {
        var groupEntity = _mapper.Map<Group>(groupCreateDto);

        var existingGroup = _unitOfWork.GroupRepository.GetByIdAsync(groupEntity.Id).Result;

        if (existingGroup == null)
        {
            return false;
        }

        existingGroup.Name = groupCreateDto.Name;
        _unitOfWork.Commit();
        return true;
    }


    private Group Get(int id)
    {
        return new Group();

    }
}