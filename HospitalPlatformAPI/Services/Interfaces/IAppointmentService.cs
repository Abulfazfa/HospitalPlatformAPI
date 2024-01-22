using HospitalPlatformAPI.DTOs.Appointment;

namespace HospitalPlatformAPI.Services.Interfaces;

public interface IAppointmentService
{
    List<ReturnAppointmentDto> Get();
    ReturnAppointmentDto GetGroupById(int id);
    bool Add(CreateAppointmentDto appointmentDto); 
    bool Delete(int id);
    bool Update(CreateAppointmentDto createDto);
}