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
        var doctors = _unitOfWork.DoctorRepository.Include(d => d.Branch).ToList();
        var list = new List<DoctorReturnDto>();
        foreach (var doctor in doctors)
        {
            list.Add(_mapper.Map<DoctorReturnDto>(doctor));
        }
        return list;
    }
    public DoctorReturnDto GetGroupById(int id)
    {
        var doctor = _unitOfWork.DoctorRepository.GetByIdAsync(id).Result;
        return _mapper.Map<DoctorReturnDto>(doctor);
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
            var doctor = _unitOfWork.DoctorRepository.GetByIdAsync(id).Result;
            var result = _unitOfWork.DoctorRepository.DeleteAsync(doctor).GetAwaiter().GetResult;
            _unitOfWork.Commit();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Update(DoctorCreateDto createDto)
    {
        var doctorEntity = _mapper.Map<Doctor>(createDto);

        var existingDoctor = _unitOfWork.DoctorRepository.GetByIdAsync(doctorEntity.Id).Result;

        if (existingDoctor == null)
        {
            return false;
        }

        existingDoctor = doctorEntity;
        _unitOfWork.Commit();
        return true;
    }
    
}