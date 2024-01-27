using AutoMapper;
using HospitalPlatformAPI.DTOs.Appointment;
using HospitalPlatformAPI.DTOs.Doctor;
using HospitalPlatformAPI.Models;
using HospitalPlatformAPI.Repositories.Interfaces;

namespace HospitalPlatformAPI.Services.Interfaces;

public class AppointmentService : IAppointmentService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AppointmentService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public List<ReturnAppointmentDto> Get()
    {
        var doctors = _unitOfWork.AppointmentRepository.GetAllAsync().Result;
        var list = new List<ReturnAppointmentDto>();
        foreach (var doctor in doctors)
        {
            list.Add(_mapper.Map<ReturnAppointmentDto>(doctor));
        }
        return list;
    }
    public ReturnAppointmentDto GetGroupById(int id)
    {
        var doctor = _unitOfWork.AppointmentRepository.GetByIdAsync(id).Result;
        return _mapper.Map<ReturnAppointmentDto>(doctor);
    }
    public bool Add(CreateAppointmentDto createAppointmentDto)
    {
        try
        {
            var appointment = _mapper.Map<Appointment>(createAppointmentDto);
       
            _unitOfWork.AppointmentRepository.AddAsync(appointment).GetAwaiter().GetResult();

            var doctor = _unitOfWork.DoctorRepository.GetByIdAsync(createAppointmentDto.DoctorId).Result;

            doctor.Appointments.Add(appointment);
            _unitOfWork.DoctorRepository.UpdateAsync(doctor);

            // Commit the changes
            _unitOfWork.Commit();

            return true;
        }
        catch (Exception e)
        {
            // Handle exceptions appropriately
            return false;
        }
    }


    public bool Delete(int id)
    {
        try
        {
            var appointment = _unitOfWork.AppointmentRepository.GetByIdAsync(id).Result;
            var result = _unitOfWork.AppointmentRepository.DeleteAsync(appointment).GetAwaiter().GetResult;
            _unitOfWork.Commit();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Update(CreateAppointmentDto createDto)
    {
        var appointment = _mapper.Map<Appointment>(createDto);

        var existingAppointment = _unitOfWork.AppointmentRepository.GetByIdAsync(appointment.Id).Result;

        if (existingAppointment == null)
        {
            return false;
        }

        existingAppointment = appointment;
        _unitOfWork.Commit();
        return true;
    }
}